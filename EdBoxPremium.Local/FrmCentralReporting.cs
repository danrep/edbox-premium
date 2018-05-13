using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CsvHelper;
using EdBoxPremium.Library;
using EdBoxPremium.Library.Dictionary;
using EdBoxPremium.Local.Engines;

namespace EdBoxPremium.Local
{
    public partial class FrmCentralReporting : Form
    {
        private bool _workingState;

        public FrmCentralReporting()
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

        private void FrmSettings_Shown(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'edboxDbDataSet.School_AttendanceSession' table. You can move, or remove it, as needed.
                this.school_AttendanceSessionTableAdapter.FillByUserRecorded(
                    this.edboxDbDataSet.School_AttendanceSession, DatabaseManager.CurrentAuthModel.AccessCredential.Id);
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void tmrProcesses_Tick(object sender, EventArgs e)
        {
            lblNotify.Visible = _workingState;
        }

        private void FrmCentralReporting_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvAttendanceSessions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvAttendanceSessions.Rows)
                {
                    var sessionId = Convert.ToInt32(row.Cells[0].Value.ToString());
                    var dataSet =
                        edboxDbDataSet.School_AttendanceSession.FirstOrDefault(x => x.Id == sessionId);

                    if (dataSet == null)
                        continue;

                    row.Cells[3].Value = DatabaseManager.SchoolCourse.FirstOrDefault(x => x.Id == dataSet.CourseId)
                                             ?.CourseCode ?? "NA";
                    row.Cells[4].Value = ((AttendanceReason)dataSet.AttendanceFunctionId).DisplayName();
                }
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void dgvAttendanceSessions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != 1)
                    return;

                fldDialogFileLocation.ShowDialog();

                new Thread(() => {
                    WriteExcel(dgvAttendanceSessions.Rows[e.RowIndex], fldDialogFileLocation.SelectedPath);
                }).Start();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void WriteExcel(DataGridViewRow gvRow, string location)
        {
            _workingState = true;

            try
            {
                var attendanceSessionId = Convert.ToInt32(gvRow.Cells[0].Value);
                var name = $"Attendance for {gvRow.Cells[4].Value} in {gvRow.Cells[3].Value}";

                using (var sw = new StreamWriter($"{location}/{name}.csv"))
                {
                    var writer = new CsvWriter(sw);

                    writer.WriteField(name);
                    writer.NextRecord();

                    writer.WriteField(@"Student Matric Number");
                    writer.WriteField(@"Record Period");
                    writer.NextRecord();

                    using (var localEntities = new LocalEntities())
                    {
                        var attendanceData = localEntities.School_Attendance
                            .Where(x => !x.IsDeleted && x.AttendanceSessionId == attendanceSessionId).Select(x => new
                            {
                                x.StudentMatricNumber, 
                                RecordPeriod = x.DateRecorded.ToString()
                            }).ToList();

                        writer.WriteRecords(attendanceData);

                        writer.WriteField(@"");
                        writer.NextRecord();
                        writer.WriteField(@"");
                        writer.NextRecord();

                        writer.WriteField(@"Total Attendance " + attendanceData.Count);
                    }
                }
            }
            catch (Exception e)
            {
                ErrorHandler.TreatError(e);
            }

            _workingState = false;
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(@"Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
