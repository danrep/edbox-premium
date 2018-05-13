using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EdBoxPremium.Core;
using EdBoxPremium.Data.InterchangeModels;
using EdBoxPremium.Library;
using EdBoxPremium.Local.Engines;

namespace EdBoxPremium.Local
{
    public partial class FrmCentral : Form
    {
        private FrmSettings _frmSettings = new FrmSettings();
        private FrmCentralSyncData _frmCentralSyncData = new FrmCentralSyncData();
        private FrmCentralReporting _frmCentralReporting = new FrmCentralReporting();
        private FrmCentralTagStudent _frmCentralTagStudent = new FrmCentralTagStudent();
        private FrmCentralTakeAttendance _frmCentralTakeAttendance = new FrmCentralTakeAttendance();

        private string _notifyMessage;
        private bool _notifyAction;
        private Color _notifyColor;
        private AuthModel _authModel;

        public FrmCentral()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                if (_frmCentralSyncData.Visible)
                {
                    _frmCentralSyncData.BringToFront();
                    return;
                }

                _frmCentralSyncData = new FrmCentralSyncData();
                _frmCentralSyncData.Show();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }

        }

        private void btnTakeAtten_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DeviceManager.DeviceSpec.Nfc))
                {
                    MessageBox.Show(@"An NFC Device has not been configured. Please do so.");
                    btnUpdateSettings_Click(sender, e);
                    return;
                }

                if(DatabaseManager.SchoolCourse == null)
                {
                    MessageBox.Show(@"A system Initialization is Required. Please pull Data from the Server before you proceed.");
                    btnSync_Click(sender, e);
                    return;
                }

                if (!DatabaseManager.SchoolCourse.Any())
                {
                    MessageBox.Show(@"Please Pull Data from the Server before you Proceed.");
                    btnSync_Click(sender, e);
                    return;
                }

                if (_frmCentralTakeAttendance.Visible)
                {
                    _frmCentralTakeAttendance.BringToFront();
                    return;
                }

                _frmCentralTakeAttendance = new FrmCentralTakeAttendance();
                _frmCentralTakeAttendance.Show();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ShutDownProcess();
            Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DatabaseManager.LocalAuthData == null)
                {
                    NotifyWarning("Please Update System Settings. This is a first time Use!");
                    return;
                }

                if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
                {
                    NotifyWarning("Please Enter a Username");
                    return;
                }

                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    NotifyWarning("Please Enter a Password");
                    return;
                }

                var credential =
                    DatabaseManager.LocalAuthData.FirstOrDefault(x =>
                        x.AccessCredential.Username == txtUsername.Text.Trim());

                if (credential == null)
                {
                    NotifyWarning("You are not recognized here. Please contact the Administrator");
                    return;
                }

                if (!Encryption.IsSaltEncryptValid(txtPassword.Text.Trim(), credential.AccessCredential.PasswordData,
                    credential.AccessCredential.PasswordSalt))
                {
                    NotifyWarning("Your password is incorrect. Please try again or contact the Administrator");
                    return;
                }

                _authModel = credential;
                DatabaseManager.CurrentAuthModel = credential;

                ShowApp(true);
                btnLogOut.Visible = true;
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void NotifyWarning(string message)
        {
            _notifyMessage = message;
            _notifyColor = Color.SaddleBrown;
            _notifyAction = true;
        }

        private void NotifyInfo(string message)
        {
            _notifyMessage = message;
            _notifyColor = Color.SteelBlue;
            _notifyAction = true;
        }

        private void ShutDownProcess()
        {
            try
            {
                _frmSettings.Dispose();
                _frmCentralSyncData.Dispose();
                _frmCentralTagStudent.Dispose();

                tmrNotify.Enabled = false;
                tmrProceed.Enabled = false;
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void ShowApp(bool control)
        {
            pnlAuthentication.Visible = !control;
            pnlBody.Visible = control;

            NotifyInfo($"Welcome {_authModel.AccessCredential.Username}. What are we doing today?");

            if (_authModel.AccessRoles.Any(x =>
                x.PermissionId == (int) RolePermissions.LocalAdministrator ||
                x.PermissionId == (int) RolePermissions.TagOpr))
                btnTagAssignment.Visible = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ShowApp(false);
            btnLogOut.Visible = false;
        }

        private void btnUpdateSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (_frmSettings.Visible)
                {
                    _frmSettings.BringToFront();
                    return;
                }

                _frmSettings = new FrmSettings();
                _frmSettings.Show();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {
            lblInfo.Visible = false;
            _notifyAction = false;
        }

        private void tmrNotify_Tick(object sender, EventArgs e)
        {
            if (!_notifyAction)
                return;

            tmrNotify.Enabled = false;
            lblInfo.Visible = true;

            lblInfo.Text = _notifyMessage;
            lblInfo.ForeColor = _notifyColor;

            Application.DoEvents();

            tmrProceed.Enabled = true;
            tmrProceed.Start();
        }

        private void tmrProceed_Tick(object sender, EventArgs e)
        {
            tmrProceed.Enabled = false;

            tmrNotify.Enabled = true;
            _notifyAction = false;
            lblInfo.Visible = false;
        }

        private void FrmCentral_Click(object sender, EventArgs e)
        {
            _frmSettings.Hide();
        }

        private void btnTagAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DeviceManager.DeviceSpec.Nfc))
                {
                    MessageBox.Show(@"An NFC Device has not been configured. Please do so.");
                    btnUpdateSettings_Click(sender, e);
                    return;
                }

                if (_frmCentralTagStudent.Visible)
                {
                    _frmCentralTagStudent.BringToFront();
                    return;
                }

                _frmCentralTagStudent = new FrmCentralTagStudent();
                _frmCentralTagStudent.Show();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (DatabaseManager.SchoolCourse == null)
            {
                MessageBox.Show(@"A system Initialization is Required. Please pull Data from the Server before you proceed.");
                btnSync_Click(sender, e);
                return;
            }

            if (!DatabaseManager.SchoolCourse.Any())
            {
                MessageBox.Show(@"Please Pull Data from the Server before you Proceed.");
                btnSync_Click(sender, e);
                return;
            }

            if (_frmCentralReporting.Visible)
            {
                _frmCentralReporting.BringToFront();
                return;
            }

            _frmCentralReporting = new FrmCentralReporting();
            _frmCentralReporting.Show();
        }

        private void FrmCentral_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void FrmCentral_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
        }

        private void pnlBody_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
