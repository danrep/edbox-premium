using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Codesistance.NFC;
using EdBoxPremium.Data.InterchangeModels;
using EdBoxPremium.Library;
using EdBoxPremium.Local.Engines;

namespace EdBoxPremium.Local
{
    public partial class FrmSettings : Form
    {
        private bool _workingState;

        public FrmSettings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                tmrProcesses.Stop();
                tmrProcesses.Enabled = false;
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }

            this.Close();
        }

        private void btnUpdateSettingsConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                new Thread(() =>
                {
                    _workingState = true;

                    var settings = RemoteRequest.Get($"{txtUrl.Text.Trim()}apisettings/PullSettings");
                    if (settings.Result.Status)
                    {
                        var settingData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<System_Setting>>(settings.Result.Data.ToString());
                        var localEntities = new LocalEntities();

                        if (!settingData.Any())
                        {
                            MessageBox.Show(@"No Settings were found on the server");
                            _workingState = false;
                            return;
                        }

                            DatabaseManager.ExecuteScripts("truncate table dbo.SystemSetting");

                        localEntities.System_Setting.AddRange(settingData.Select(sd => new System_Setting()
                        {
                            IsDeleted = false, 
                            SettingDate = DateTime.Now, 
                            SettingKey = sd.SettingKey, 
                            SettingValue = sd.SettingValue
                        }));
                        localEntities.SaveChanges();
                        DatabaseManager.UpdateSpec = new UpdateSpec()
                        {
                            DatabaseFiles = DatabaseManager.UpdateSpec.DatabaseFiles,
                            DatabaseSchema = DatabaseManager.UpdateSpec.DatabaseSchema,
                            RemoteUrl = settingData.FirstOrDefault(x => x.SettingKey == (int) SettingKey.RemoteApi)
                                            ?.SettingValue ?? ""
                        };
                    }
                    else
                    {
                        MessageBox.Show(@"The server cannot be reached at the moment. Please try again later!");
                    }


                    settings = RemoteRequest.Get($"{txtUrl.Text.Trim()}ApiUserManagement/Pullusers");

                    if (settings.Result.Status)
                    {
                        DatabaseManager.LocalAuthData =
                            Newtonsoft.Json.JsonConvert.DeserializeObject<List<AuthModel>>(
                                Newtonsoft.Json.JsonConvert.SerializeObject(settings.Result.Data));

                        var x = DatabaseManager.LocalAuthData;
                    }
                    else
                    {
                        MessageBox.Show(@"The server cannot be reached at the moment. Please try again later!");
                    }
                    _workingState = false;
                }).Start();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void FrmSettings_Shown(object sender, EventArgs e)
        {
            txtUrl.Text = DatabaseManager.UpdateSpec.RemoteUrl;
            LoadReaderList();

            comboBox1.SelectedItem = DeviceManager.DeviceSpec.Nfc;
        }

        private void tmrProcesses_Tick(object sender, EventArgs e)
        {
            lblNotify.Visible = _workingState;
            picNotify.Visible = !_workingState;
        }

        private void btnUpdateDevices_Click(object sender, EventArgs e)
        {
            try
            {
                _workingState = true;

                var devices = DeviceManager.DeviceSpec;
                devices.Nfc = comboBox1.SelectedItem.ToString();

                DeviceManager.DeviceSpec = devices;

                _workingState = false;
            }
            catch (Exception ex)
            {
                ErrorHandler.TreatError(ex);
            }
        }

        private void LoadReaderList()
        {
            try
            {
                Section:
                var readers = SCARD.Readers;

                comboBox1.BeginUpdate();
                comboBox1.Items.Clear();
                if (readers != null)
                {
                    foreach (var t in readers)
                    {
                        comboBox1.Items.Add(t);
                    }

                    comboBox1.SelectedIndex = -1;
                }
                else
                {
                    var d = MessageBox.Show(
                        @"It would seem that there are no Card Readers connected. Do you wish to check again? Please ensure that the Device is Properly Connected.",
                        @"Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (d == DialogResult.Yes)
                    {
                        GC.Collect();
                        goto Section;
                    }
                }
                comboBox1.EndUpdate();
            }
            catch (Exception ex)
            {
                ErrorHandler.TreatError(ex);
            }
        }
    }
}
