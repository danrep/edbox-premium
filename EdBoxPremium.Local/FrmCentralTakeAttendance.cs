using Codesistance.NFC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;
using EdBoxPremium.Library;
using EdBoxPremium.Library.Dictionary;
using EdBoxPremium.Local.Engines;
using EdBoxPremium.Local.Properties;

namespace EdBoxPremium.Local
{
    public partial class FrmCentralTakeAttendance : Form
    {
        private SCardReader _reader;
        private SCardChannel _cardchannel = null;
        private NfcTag _tag = null;
        private Thread _cardthread;
        
        private string _tagATR;
        private string _tagUID;
        private bool _inLoop = false;

        private string _messageDataBody;
        private Color _messageColor;
        private bool _workingState = false;

        private Student_ProfileData _studentData;
        private List<School_Attendance> _schoolAttendances;

        public FrmCentralTakeAttendance()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseProcess();
        }

        private void CloseProcess()
        {
            try
            {
                tmrTagMonitor.Enabled = false;
                tmrEvents.Enabled = false;
            }
            catch (Exception e)
            {
                ErrorHandler.TreatError(e);
            }
            this.Close();
        }

        private void grpBoxSettingsUpdate_Enter(object sender, EventArgs e)
        {

        }

        private void FrmCentralTagStudent_Load(object sender, EventArgs e)
        {
            _schoolAttendances = new List<School_Attendance>();
        }

        private void WarnNotify(string messageData)
        {
            _messageDataBody = messageData;
            _messageColor = Color.DarkOrange;
        }

        private void ErrorNotify(string messageData)
        {
            _messageDataBody = messageData;
            _messageColor = Color.Red;
        }

        private void SuccessNotify(string messageData)
        {
            _messageDataBody = messageData;
            _messageColor = Color.Green;
        }

        private void InfoNotify(string messageData)
        {
            _messageDataBody = messageData;
            _messageColor = Color.SteelBlue;
        }

        private void tmrEvents_Tick(object sender, EventArgs e)
        {
            lblNotify.Visible = _workingState;

            if (!string.IsNullOrEmpty(_messageDataBody))
            {
                var componentMessage = _messageDataBody.Split('|');
                lblInfoHead.Text = componentMessage[0];
                lblInfoBody.Text = componentMessage[1];
            }

            lblInfoHead.ForeColor = lblInfoBody.ForeColor = _messageColor;

            DisplayStudentData(_studentData);

            btnAcceptAttendance.Visible = _studentData != null;
        }

        private void DisplayStudentData(Student_ProfileData studentProfileData)
        {
            if (studentProfileData == null)
            {
                picBxStudentImage.Image = Resources.logo_only_128;
                lblCurrentStudentName.Text = @"Waiting for Student";
                lblCurrentStudentStatus.Text = @"Please Place a Tag";
                picBxStudentImageDup.Image = Resources.logo_only_128;
                picBxStudentImageDup.Visible = false;
                return;
            }

            lblCurrentStudentName.Text = studentProfileData.LastName + @", " + studentProfileData.FirstName;
            lblCurrentStudentStatus.Text = $"Program: {studentProfileData.Program} | Department: {studentProfileData.Department}\n";
            lblCurrentStudentStatus.Text += $"Sex: {studentProfileData.Sex} | Blood Group: {studentProfileData.BloodGroup}\n";
            
            lblCurrentStudentStatus.Text += $"Phone: {studentProfileData.Phone} | Email: {studentProfileData.Email}";
            
            if (string.IsNullOrEmpty(studentProfileData.Picture))
                return;

            var imageBytes = Convert.FromBase64String(studentProfileData.Picture);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                picBxStudentImage.Image = Image.FromStream(ms, true);
            }
        }

        private void FrmCentralTagStudent_Shown(object sender, EventArgs e)
        {
            SetReader(DeviceManager.DeviceSpec.Nfc);
            
            SetCombo(EnumDictionary.GetList<AttendanceReason>(), cmbAttendanceReason);
            SetCombo(DatabaseManager.SchoolCourse.Select(x => new EnumList()
            {
                ItemId = x.Id,
                ItemName = x.CourseCode
            }).ToList(), cmbCourse);
        }

        private static void SetCombo(List<EnumList> dataList, ComboBox comboBox)
        {
            var bindingSource = new BindingSource {DataSource = dataList};
            comboBox.DataSource = bindingSource.DataSource;
            comboBox.DisplayMember = "ItemName";
            comboBox.ValueMember = "ItemId";

            Application.DoEvents();
        }

        private void SetReader(string readerName)
        {
            try
            {
                _reader = new SCardReader(readerName);
                _reader.StartMonitor(new SCardReader.StatusChangeCallback(ReaderStatusChanged));
                InfoNotify("Connection Status|Current Reader is " + readerName);
            }
            catch (Exception ex)
            {
                ErrorHandler.TreatError(ex);
                MessageBox.Show(@"You cannot Proceed without a working NFC Reader. Please check!");
                this.CloseProcess();
            }
        }

        private string RemoveSpaces(string text)
        {
            var result = "";
            foreach (var t in text)
            {
                if (t.ToString() != " ")
                {
                    result += t;
                }
            }
            return result;
        }

        private void card_read_proc()
        {
            NfcTag tag = null;
            string msg = null;
            try
            {
                if (NfcTagType2.RecognizeAtr(_cardchannel))
                {
                    if (NfcTagType2.Recognize(_cardchannel))
                    {
                        tag = NfcTagType2.Create(_cardchannel);
                        if (tag == null)
                            WarnNotify("Warning|An error has occured while reading the Tag's content");
                    }
                    else
                    {
                        msg = "From the ATR it may be a NFC type 2 Tag, but the content is invalid";
                        WarnNotify("Warning|" + msg);
                    }
                }
                else
                {
                    if (NfcTagType4.Recognize(_cardchannel))
                    {
                        tag = NfcTagType4.Create(_cardchannel);
                        if (tag == null)
                        {
                            msg = "An error has occured while reading the Tag's content";
                            WarnNotify("Warning|" + msg);
                        }
                    }
                    else
                    {
                        msg = "Unrecognized or unsupported card";
                        WarnNotify("Warning|" + msg);
                    }
                }

                if (tag != null)
                {
                    this.BeginInvoke(new OnTagReadInvoker(OnTagRead), tag);
                }
                else
                {
                    this.BeginInvoke(new OnErrorInvoker(OnError), msg, "This is not a valid NFC Tag");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.TreatError(ex);
            }
        }

        delegate void ReaderStatusChangedInvoker(uint ReaderState, CardBuffer CardAtr);

        void ReaderStatusChanged(uint readerState, CardBuffer cardAtr)
        {
            try
            {
                string msg;

                if (InvokeRequired)
                {
                    this.BeginInvoke(new ReaderStatusChangedInvoker(ReaderStatusChanged), readerState, cardAtr);
                    return;
                }

                SCARD.ReaderStatusToString(readerState);

                if (cardAtr != null)
                {
                    _tagATR = RemoveSpaces(cardAtr.AsString(" "));
                }
                else
                {

                }

                if (readerState == SCARD.STATE_UNAWARE)
                {
                    if (_cardchannel != null)
                    {
                        _cardchannel.Disconnect();
                        _cardchannel = null;
                    }

                    if (!_inLoop)
                    {
                        msg = "The reader we were working with has gone AWOL from the system.";
                        WarnNotify("Warning|" + msg);
                        _inLoop = true;
                    }

                    tmrTagMonitor.Enabled = true;
                    msg = "Reader not Found. Please check Connection.";
                    WarnNotify("Warning|" + msg);
                }
                else if ((readerState & SCARD.STATE_EMPTY) != 0)
                {
                    _tag = null;
                    _inLoop = false;

                    _studentData = null;
                    InfoNotify("Ready|Please insert another card for Tagging");

                    if (_cardchannel == null)
                        return;

                    _cardchannel.Disconnect();
                    _cardchannel = null;
                }
                else if ((readerState & SCARD.STATE_UNAVAILABLE) != 0)
                {
                }
                else if ((readerState & SCARD.STATE_MUTE) != 0)
                {

                }
                else if ((readerState & SCARD.STATE_INUSE) != 0)
                {
                    _inLoop = false;
                }
                else if ((readerState & SCARD.STATE_PRESENT) != 0)
                {
                    _inLoop = false;
                    if (_cardchannel != null)
                        return;

                    _cardchannel = new SCardChannel(DeviceManager.DeviceSpec.Nfc);

                    if (_cardchannel.Connect())
                    {
                        var mifare = new MiFareCardProg();
                        _tagUID = RemoveSpaces(mifare.GetUID(DeviceManager.DeviceSpec.Nfc).Trim());

                        _cardthread = new Thread(card_read_proc);
                        _cardthread.Start();
                    }
                    else
                    {
                        msg =
                            "NearField failed to connect to the card in the reader. Check that you don't have another application running in background that tries to work with the smartcards in the same time as NearField";
                        WarnNotify("Warning|" + msg);
                        _cardchannel = null;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.TreatError(ex);
            }
        }

        delegate void OnTagReadInvoker(NfcTag _tag);
        void OnTagRead(NfcTag tag)
        {
            try
            {
                string msg;
                _tag = tag;
                _studentData = null;

                if (_tag == null)
                {
                    msg = "Internal error, The Tag is Invalid!";
                    WarnNotify("Warning|" + msg);
                    return;
                }

                if ((tag.Content == null) || (tag.Content.Count == 0))
                {
                    if (!tag.IsLocked())
                    {
                        msg = "The Device has no valid content yet. You may proceed with Tag Writting.";
                        WarnNotify("Warning|" + msg);
                    }
                    else
                    {
                        msg = "The Tag has no valid content, but is not writable";
                        WarnNotify("Warning|" + msg);
                    }
                }
                else
                {
                    var ndef = tag.Content.FirstOrDefault();
                    switch (ndef)
                    {
                        case null:
                            msg = "This Tag is Empty.";
                            WarnNotify("Warning|" + msg);
                            return;
                        case RtdSmartPoster smart:
                            using (var localEntities = new LocalEntities())
                            {
                                var matricNumber = smart.Title.FirstOrDefault()?.Value ?? "";
                                _studentData =
                                    localEntities.Student_ProfileData.FirstOrDefault(x =>
                                        x.MatricNumber == matricNumber && x.TagId == _tagUID);

                                msg = _studentData == null
                                    ? "No Student Record, Access Denied."
                                    : $"{_studentData.FirstName} {_studentData.LastName}, Access Granted";

                                var speak = new SpeechSynthesizer();
                                speak.SpeakAsync(msg);
                            }

                            SuccessNotify("Awesome|" + msg);
                            break;
                        default:
                            msg = "Data found but its not an EdBoxPremium Data.";
                            WarnNotify("Warning|" + msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.TreatError(ex);
            }
        }

        delegate void OnErrorInvoker(string text, string caption);
        void OnError(string text, string caption)
        {
            ErrorNotify($"{caption}|{text}");
        }

        private void tmrTagMonitor_Tick(object sender, EventArgs e)
        {
            tmrTagMonitor.Enabled = false;
            try
            {
                SetReader(DeviceManager.DeviceSpec.Nfc);
            }
            catch (Exception ex)
            {
                ErrorHandler.TreatError(ex);
            }
        }

        private void btnFinalizeAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDesc.Text.Trim()))
                    txtDesc.Text = @"NA";
                
                var dialogResult =
                    MessageBox.Show(
                        $@"Are you sure you want to Finalize this Session for {cmbCourse.Text} {
                                cmbAttendanceReason.Text
                            }. This is Irreversable!",
                        @"Waiting for Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes)
                    return;

                using (var localEntities = new LocalEntities())
                {
                    var attendanceSession = new School_AttendanceSession()
                    {
                        IsDeleted = false, 
                        AcademicPeriodId = 0, 
                        AttendanceDescription = txtDesc.Text,
                        AttendanceFunctionId = (int)cmbAttendanceReason.SelectedValue, 
                        AttendanceSessionGuid = Guid.NewGuid().ToString().ToUpper(), 
                        CourseId = (int)cmbCourse.SelectedValue, 
                        DateRecorded = DateTime.Now, 
                        IsUploaded = false, 
                        UserRecorded = DatabaseManager.CurrentAuthModel.AccessCredential.Id
                    };

                    localEntities.School_AttendanceSession.Add(attendanceSession);
                    localEntities.SaveChanges();

                    foreach (var attendance in _schoolAttendances)
                    {
                        attendance.AttendanceSessionId = attendanceSession.Id;
                    }

                    localEntities.School_Attendance.AddRange(_schoolAttendances);
                    localEntities.SaveChanges();
                }

                MessageBox.Show(@"Attendance Taken Successfully");
                this.CloseProcess();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void picBxStudentImage_Click(object sender, EventArgs e)
        {
            picBxStudentImageDup.Image = picBxStudentImage.Image;
            picBxStudentImageDup.Visible = true;
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("yyyy MMMM dd hh:mm:ss tt");
        }

        private void btnAcceptAttendance_Click(object sender, EventArgs e)
        {

            if (_schoolAttendances.Any(x => x.StudentMatricNumber == _studentData.MatricNumber))
            {
                WarnNotify("Not Allowed|This Student has already been Noted");
                return;
            }

            _schoolAttendances.Add(new School_Attendance()
            {
                IsDeleted = false, 
                AttendanceSessionId = 0, 
                DateRecorded = DateTime.Now, 
                StudentMatricNumber = _studentData.MatricNumber, 
                StudentTagId = _tagUID
            });

            lstTakenAttendance.Items.Add($"{_studentData.MatricNumber}: {_tagUID}");
            _studentData = null;
        }

        private void picBxStudentImageDup_Click(object sender, EventArgs e)
        {
            picBxStudentImageDup.Visible = false;
        }
    }
}
