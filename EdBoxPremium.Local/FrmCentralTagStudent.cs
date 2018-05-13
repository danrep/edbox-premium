using Codesistance.NFC;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EdBoxPremium.Data.InterchangeModels;
using EdBoxPremium.Local.Engines;
using EdBoxPremium.Local.Properties;
using Newtonsoft.Json;

namespace EdBoxPremium.Local
{
    public partial class FrmCentralTagStudent : Form
    {
        private SCardReader _reader;
        private SCardChannel _cardchannel = null;
        private NfcTag _tag = null;
        private Thread _cardthread;
        
        private string _tagUID;
        private bool _inLoop = false;

        private string _messageDataBody;
        private Color _messageColor;
        private bool _workingState;

        private StudentCompleteData _studentData;

        public FrmCentralTagStudent()
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

        }

        private void btnStudentRequest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentMatric.Text.Trim()))
            {
                WarnNotify("Warning|Please enter a Matric Number");
                return;
            }

            new Thread(() =>
            {
                try
                {
                    _workingState = true;

                    InfoNotify("Please Wait!|Searching for the Student.");

                    var settings =
                        RemoteRequest.Get(
                            $"{DatabaseManager.UpdateSpec.RemoteUrl}ApiStudentManagement/PullStudentDataByMatricNumber?matricNumber={txtStudentMatric.Text.Trim()}");
                    if (settings.Result.Status)
                    {
                        _studentData =
                            JsonConvert.DeserializeObject<StudentCompleteData>(
                                JsonConvert.SerializeObject(settings.Result.Data));

                        if (string.IsNullOrEmpty(_studentData.StudentProfileData.TagId))
                            WarnNotify("Awesome!|This is a valid student but it does not have a Tag Yet.");
                        else
                        { SuccessNotify($"Awesome!|The Tag is Valid. Tag Id is {_tagUID} and Matriculation Number is {_studentData.StudentProfileData.MatricNumber}"); }
                    }
                    else
                    {
                        WarnNotify("Oops!|" + settings.Result.Message);
                    }

                    _workingState = false;
                }
                catch (Exception exception)
                {
                    ErrorHandler.TreatError(exception);
                }
            }).Start();
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
        }

        private void DisplayStudentData(StudentCompleteData studentProfileData)
        {
            if (studentProfileData == null)
            {
                picBxStudentImage.Image = Resources.logo_only_128;
                lblCurrentStudentName.Text = @"Waiting for Student";
                lblCurrentStudentStatus.Text = @"Please search for a Student or Place a Tag";
                return;
            }

            lblCurrentStudentName.Text = studentProfileData.StudentProfileData.LastName + @", " + studentProfileData.StudentProfileData.FirstName;
            lblCurrentStudentStatus.Text = $"Sex: {studentProfileData.StudentProfileData.Sex} | Phone: {studentProfileData.StudentProfileData.Phone}\n";
            lblCurrentStudentStatus.Text += $@"Email: {studentProfileData.StudentProfileData.Email}";

            if (string.IsNullOrEmpty(studentProfileData.StudentProfileData.Picture))
                return;

            var imageBytes = Convert.FromBase64String(studentProfileData.StudentProfileData.Picture);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                picBxStudentImage.Image = Image.FromStream(ms, true);
            }
        }

        private void FrmCentralTagStudent_Shown(object sender, EventArgs e)
        {
            SetReader(DeviceManager.DeviceSpec.Nfc);
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

        private void card_write_proc(object _tag)
        {
            try
            {
                var tag = _tag as NfcTag;
                var again = true;

                WriteAgain:
                var start = new DateTime();

                if (tag != null && tag.Format())
                {
                    while (DateTime.Now.Subtract(start).TotalSeconds < 2)
                    {
                    }

                    if (tag.Write())
                    {
                        var msg = $"Assigned Tag with UID {_tagUID} to Student with Matric Number {_studentData.StudentProfileData.MatricNumber} Successfully";
                        SuccessNotify("Success|" + msg);
                        this.BeginInvoke(new OnTagWriteInvoker(OnTagWrite), tag);
                    }
                    else
                    {
                        if (again)
                        {
                            again = false;
                            goto WriteAgain;
                        }

                        const string msg = "Tag Write Failure. Please try again or contact Support.";
                        ErrorNotify("Warning|" + msg);
                    }
                }
                else
                {
                    const string msg = "Tag Format Failure. Please try again or contact Support.";
                    WarnNotify("Warning|" + msg);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.TreatError(ex);
            }
        }

        private void card_format_proc(NfcTag _tag)
        {
            try
            {
                var again = true;

                FormatAgain:
                if (_tag.Format())
                {
                    var msg = "Formatted Tag with UID " + _tagUID + " Successfully.";
                    SuccessNotify("Success|" + msg);
                    this.BeginInvoke(new OnTagFormatInvoker(OnTagFormat), _tag);
                }
                else
                {
                    if (again)
                    {
                        again = false;
                        goto FormatAgain;
                    }

                    var msg = "Tag Format Failure. Please try again or contact Support.";
                    WarnNotify("Warning|" + msg);
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
                    //_tagATR = RemoveSpaces(cardAtr.AsString(" "));
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
                    txtStudentMatric.Clear();

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

        delegate void OnTagWriteInvoker(NfcTag _tag);
        void OnTagWrite(NfcTag _tag)
        {
            try
            {
                MessageBox.Show(@"Tag Write Successful.");
                card_read_proc();
            }
            catch (Exception ex)
            {
                ErrorHandler.TreatError(ex);
            }
        }

        delegate void OnTagFormatInvoker(NfcTag _tag);
        void OnTagFormat(NfcTag _tag)
        {
            try
            {
                MessageBox.Show(@"Tag Format Successful.");
                card_read_proc();
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
                            txtStudentMatric.Text = smart.Title.FirstOrDefault()?.Value ?? "";

                            btnStudentRequest_Click(this, EventArgs.Empty);

                            msg = "Valid EdBoxPremium Student.";
                            SuccessNotify("Awesome|" + msg);
                            break;
                        default:
                            msg = "Data found but its not a EdBoxPremium Data.";
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

        private void btnFormat_Click(object sender, EventArgs e)
        {
            if(_tag == null)
                return;

            if (!CheckTagValidity())
            {
                var dialogResult =
                    MessageBox.Show(
                        @"The Current Tag has some data on it? This operation will totally overwrite it. Should I proceed?",
                        @"Waiting for Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes)
                    return;

                if (!RemoteTagClean())
                    return;
            }

            _tag.Content.Clear();
            _cardthread = new Thread(() => { card_format_proc(_tag); });
            _cardthread.Start();
        }

        private bool CheckTagValidity()
        {
            var tagContent = _tag.Content.FirstOrDefault();
            return ((RtdSmartPoster) tagContent)?.Title.FirstOrDefault() == null;
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentMatric.Text.Trim() != _studentData.StudentProfileData.MatricNumber)
                {
                    MessageBox.Show(
                        @"Please request for the Student you wish to Tag. Some modifications have been made to the information retrieved.");
                    return;
                }

                if (_tag == null)
                {
                    MessageBox.Show(
                        @"Lets start over. Close this message and Place a blank Tag");
                    return;
                }

                if (!CheckTagValidity())
                {
                    var dialogResult =
                        MessageBox.Show(
                            @"The Current Tag has some data on it? This operation will totally overwrite it. Should I proceed?",
                            @"Waiting for Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult != DialogResult.Yes)
                        return;
                }

                if (!RemoteTagClean())
                    return;

                var settings =
                    RemoteRequest.Get(
                        $"{DatabaseManager.UpdateSpec.RemoteUrl}ApiStudentManagement/TagStudent?matricNumber={txtStudentMatric.Text.Trim()}&tagId={_tagUID}");

                if (!settings.Result.Status)
                {
                    MessageBox.Show(
                        @"Cannot Write Tag at the moment. Why? " + settings.Result.Message);
                    return;
                }

                var smartPoster = new RtdSmartPoster();
                smartPoster.Title.Add(new RtdText(_studentData.StudentProfileData.MatricNumber, "US"));
                Ndef ndefData = smartPoster;

                _tag.Content.Clear();
                _tag.Content.Add(ndefData);
                _cardthread = new Thread(() => { card_write_proc(_tag); });
                _cardthread.Start();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private bool RemoteTagClean()
        {
            try
            {
                var settings =
                    RemoteRequest.Get(
                        $"{DatabaseManager.UpdateSpec.RemoteUrl}ApiStudentManagement/UnTagStudent?tagId={_tagUID}");

                MessageBox.Show(settings.Result.Message);
                return true;
            }
            catch (Exception e)
            {
                ErrorHandler.TreatError(e);
                MessageBox.Show(@"Can not Format the Tag at the moment. Cant seem to reach the Server");
                return false;
            }
        }
    }
}
