using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EdBoxPremium.Data;
using EdBoxPremium.Data.InterchangeModels;
using EdBoxPremium.Local.Engines;

namespace EdBoxPremium.Local
{
    public partial class FrmCentralSyncData : Form
    {
        private string _consoleInfoData = "";

        public FrmCentralSyncData()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseProcess();
        }

        private void CloseProcess()
        {
            tmrConsole.Enabled = false;
            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                rTxtBox.Clear();

                new Thread(() =>
                {
                    PullCourses();
                    PullAcademicData();
                    PullStudents();
                }).Start();
            }
            catch (Exception exception)
            {
                ErrorHandler.TreatError(exception);
            }
        }

        private void PullStudents()
        {
            try
            {
                var listOfProfileData = new List<List<Data.Student_ProfileData>>();
                var listOfAcademicData = new List<List<Student_RegistrationData>>();

                var done = 0;

                _consoleInfoData = "Starting Pull of Student Data";
                while (true)
                {
                    var settings =
                        RemoteRequest.Get(
                            $"{DatabaseManager.UpdateSpec.RemoteUrl}ApiStudentManagement/PullStudentsCompleteData?done={done}");

                    if (settings.Result.Status)
                    {
                        var batch = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StudentCompleteData>>(
                            Newtonsoft.Json.JsonConvert.SerializeObject(settings.Result.Data));

                        if (!batch.Any())
                            break;

                        listOfProfileData.Add(batch.Select(x => x.StudentProfileData).ToList());
                        listOfAcademicData.Add(batch
                            .Select(x => x.StudentData.FirstOrDefault()?.StudentRegistrationData).ToList());

                        done += batch.Count;
                        _consoleInfoData = $"Pulled Student Batch of {batch.Count}. Total Pulled is {done}";
                    }
                    else
                    {
                        _consoleInfoData = $"Issue with Synchronization of Student Data. Please contact the Adminsitrator";
                        return;
                    }
                }

                if (listOfProfileData.Any())
                {
                    _consoleInfoData = @"Discarding all Previous Records";
                    DatabaseManager.ExecuteScripts("truncate table dbo.Student_ProfileData");

                    using (var data = new LocalEntities())
                    {
                        _consoleInfoData = @" Persisting Student Profile Data";
                        foreach (var list in listOfProfileData)
                        {
                            _consoleInfoData = @"Processing ...";
                            data.Student_ProfileData.AddRange(list.Select(innerList => new Student_ProfileData()
                            {
                                MatricNumber = innerList.MatricNumber,
                                TagId = innerList.TagId,
                                IsDeleted = false,
                                Phone = innerList.Phone,
                                FirstName = innerList.FirstName,
                                Email = innerList.Email,
                                LastName = innerList.LastName,
                                Sex = innerList.Sex,
                                Picture = innerList.Picture,
                                BloodGroup = innerList.BloodGroup ?? "",
                                PictureEncoded =
                                    string.IsNullOrEmpty(innerList.Picture)
                                        ? null
                                        : Convert.FromBase64String(innerList.Picture),
                                StudentProfileData = Newtonsoft.Json.JsonConvert.SerializeObject(innerList),
                                RemoteId = innerList.Id
                            }));
                            data.SaveChanges();
                        }
                        _consoleInfoData = @"Student Profile Data Persistence Successful";

                        _consoleInfoData = @"Persisting Student Academic Data";
                        foreach (var acadBatch in listOfAcademicData)
                        {
                            _consoleInfoData = @"Processing ...";
                            foreach (var acad in acadBatch)
                            {
                                var profile =
                                    data.Student_ProfileData.FirstOrDefault(x => x.RemoteId == acad.StudentId);

                                if (profile == null)
                                    continue;

                                var school =
                                    DatabaseManager.AcademicSetUpData.AcademicSetUpDatum.FirstOrDefault(x =>
                                        x.SchoolSubSchool.Id == acad.SubSchoolId);

                                if (school == null)
                                    continue;

                                profile.Program = school.SchoolSubSchool.SubSchoolName;
                                profile.Department = school.SchoolSubSchoolDepartment
                                    .FirstOrDefault(x => x.Id == acad.SubSchoolDepartmentId)?.SubSchoolDepartmentName;

                                data.Entry(profile).State = EntityState.Modified;
                            }
                            data.SaveChanges();
                        }
                        _consoleInfoData = @"Student Academic Data Persistence Successful";
                    }
                    _consoleInfoData = @"Completed Pull of Student Data";
                }
                else
                    _consoleInfoData = @"No Records found at this time.";
            }
            catch (Exception e)
            {
                ErrorHandler.TreatError(e);
            }
        }

        private void PullCourses()
        {
            try
            {
                _consoleInfoData = "Starting Pull of Courses Data";

                var settings =
                    RemoteRequest.Get(
                        $"{DatabaseManager.UpdateSpec.RemoteUrl}ApiSettings/PullCourses");

                if (settings.Result.Status)
                {
                    DatabaseManager.SchoolCourse =
                        Newtonsoft.Json.JsonConvert.DeserializeObject<List<School_Course>>(
                            Newtonsoft.Json.JsonConvert.SerializeObject(settings.Result.Data));

                    _consoleInfoData = $"Pulled Courses Successfully";
                }
                else
                {
                    _consoleInfoData = $"Issue with Synchronization of Courses Data. Please contact the Adminsitrator";
                    return;
                }
            }
            catch (Exception e)
            {
                ErrorHandler.TreatError(e);
            }
        }

        private void PullAcademicData()
        {
            try
            {
                _consoleInfoData = "Starting Pull of Academic Data";

                var settings =
                    RemoteRequest.Get(
                        $"{DatabaseManager.UpdateSpec.RemoteUrl}ApiSettings/PullAcademicData");

                if (settings.Result.Status)
                {
                    DatabaseManager.AcademicSetUpData =
                        Newtonsoft.Json.JsonConvert.DeserializeObject<AcademicSetUpData>(
                            Newtonsoft.Json.JsonConvert.SerializeObject(settings.Result.Data));

                    _consoleInfoData = $"Pulled Academic Data Successfully";
                }
                else
                {
                    _consoleInfoData = $"Issue with Synchronization of Academic Data. Please contact the Adminsitrator";
                    return;
                }
            }
            catch (Exception e)
            {
                ErrorHandler.TreatError(e);
            }
        }

        private void tmrConsole_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_consoleInfoData))
                return;
            
            rTxtBox.AppendText($"{DateTime.Now:yyyyMMddHHmmssfff}: {_consoleInfoData}\n");
            _consoleInfoData = null;
            rTxtBox.ScrollToCaret();
        }
    }
}
