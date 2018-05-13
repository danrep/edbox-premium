using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using EdBoxPremium.Local.Engines;

namespace EdBoxPremium.Local
{
    public partial class FrmSplash : Form
    {
        private bool _closing;

        public FrmSplash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

        private void tmrExecution_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrExecution.Enabled = false;

                if (_closing)
                    this.Close();
                else
                {
                    this.Hide();
                    var central = new FrmCentral();
                    central.ShowDialog();
                    this.Show();
                    _closing = true;
                }

                SetInfo("Shutting Down...", 100);
                tmrExecution.Enabled = true;
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void Splash_Shown(object sender, EventArgs e)
        {
            try
            {
                SetInfo("Checking Database Management Engine!", 30);
                DatabaseManager.IntializeDataStoreEngine();

                SetInfo("Checking Database Storage System!", 60);
                DatabaseManager.InitializeDataStore();

                SetInfo("Almost Done!", 99);
                tmrExecution.Enabled = true;
                tmrExecution.Start();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void SetInfo(string message, int bar)
        {
            lblInfo.Text = message;
            prgBar.Value = bar;
            Application.DoEvents();
        }

        private void Splash_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var processes =
                    Process.GetProcesses().Where(x => x.ProcessName.Contains("EdBoxPremium.Local")).ToList();

                foreach (var proc in processes)
                    proc.Kill();

                tmrExecution.Enabled = false;
            }
            catch
            {
                //
            }
            finally
            {
                GC.Collect();
                Application.Exit();
            }
        }
    }
}
