using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Hosting;
using System.Web.Mvc;
using EdBoxPremium.Core;
using EdBoxPremium.Data;
using EdBoxPremium.Data.InterchangeModels;
using EdBoxPremium.Library;
using ExcelDataReader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EdBoxPremium.Web.Controllers
{
    public class DataManagementController : _BaseController
    {
        // GET: DataManagement
        private List<string> _returnDataPerTable = new List<string>();

        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Uploads");
        }

        public ActionResult Uploads()
        {
            return View();
        }

        #region File Processing

        public JsonResult UploadFile()
        {
            var isSavedSuccessfully = true;

            try
            {
                foreach (string fileName in Request.Files)
                {
                    var file = Request.Files[fileName];

                    if (file == null || file.ContentLength <= 0)
                        continue;

                    var location =
                        $"{HostingEnvironment.ApplicationPhysicalPath}DataFiles";

                    if (!Directory.Exists(location))
                        Directory.CreateDirectory(location);

                    var directory = new DirectoryInfo(location);

                    var path = $"{directory.FullName}\\{file.FileName}";
                    file.SaveAs(path);
                }
            }
            catch (Exception ex)
            {
                ActivityLogger.Log(ex);
                isSavedSuccessfully = false;
            }

            return
                Json(isSavedSuccessfully
                    ? ResponseData.SendSuccessMsg(message: "File(s) was Uploaded Successfully")
                    : ResponseData.SendSuccessMsg(message: "Error in saving file"));
        }

        public ActionResult DeleteFile(string name)
        {
            try
            {
                var location =
                    $"{HostingEnvironment.ApplicationPhysicalPath}DataFiles";
                var directory = new System.IO.DirectoryInfo(location);

                var path = $"{directory.FullName}\\{name}";
                System.IO.File.Delete(path);

                return Json(new { Message = "File(s) was Deleted Successfully", Status = true });
            }
            catch (Exception ex)
            {
                ActivityLogger.Log(ex);
                return Json(new { Message = "Error in Deleting file", Status = false });
            }
        }

        public ActionResult ProcessFile(int fileProcessingMethod, List<string> files, bool forceReplace, string notifyDestination)
        {
            try
            {
                var location =
                    $"{HostingEnvironment.ApplicationPhysicalPath}DataFiles";

                var directory = new DirectoryInfo(location);

                foreach (var file in files)
                {
                    var path = $"{directory.FullName}\\{file}";
                    var trackingGuid = Guid.NewGuid().ToString().Trim();

                    if (!System.IO.File.Exists(path))
                    {
                        ActivityLogger.Log("INFO", $"Upload of {file} must have failed. The file was not found.");
                        continue;
                    }

                    var asyncProc = new Thread(() =>
                    {
                        ActivityLogger.Log("INFO", $"Upload of {file} Started. Tracking ID: {trackingGuid}");

                        var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read);
                        var reader = ExcelReaderFactory.CreateReader(stream);
                        var dataSet = reader.AsDataSet();
                        dataSet.DataSetName = file;

                        switch (fileProcessingMethod)
                        {
                            case (int)FileProcessingMethod.EdBoxPre:
                                ProcessStudentEdBoxPre(dataSet, forceReplace, notifyDestination);
                                break;
                            case (int)FileProcessingMethod.SchoolCustom:
                                ProcessStudentSchoolCustom(dataSet, forceReplace, notifyDestination);
                                break;
                        }

                        reader.Close();
                        stream.Close();

                        System.IO.File.Delete(path);

                        ActivityLogger.Log("INFO", $"Upload of {file} Completed. Tracking ID: {trackingGuid}");
                    })
                    {
                        Name = $"FP|{trackingGuid}|{file}|{DateTime.Now}"
                    };
                    asyncProc.Start();
                }

                return
                    Json(
                        new
                        {
                            Message = "Files have been sent for Processing. You will get an Email afterwards!",
                            Status = true
                        });
            }
            catch (Exception ex)
            {
                ActivityLogger.Log(ex);
                return Json(new { Message = "Error in Processing file", Status = false });
            }
        }

        private void ProcessStudentEdBoxPre(DataSet dataSet, bool forceReplace, string notifyDestination)
        {
            try
            {
                var innerentities = new Entities();
                var returnData = new List<List<string>>();

                foreach (DataTable table in dataSet.Tables)
                {
                    _returnDataPerTable = new List<string>();
                    
                    foreach (DataRow dataRow in table.Rows)
                    {
                        var matricNumber = dataRow[0].ToString().Trim();

                        if (string.IsNullOrEmpty(matricNumber))
                            continue;

                        var studentData =
                            innerentities.Student_ProfileData.FirstOrDefault(
                                x => !x.IsDeleted && x.MatricNumber == matricNumber);

                        try
                        {
                            if (forceReplace)
                            {
                                if (studentData == null)
                                {
                                    var newStudentInfo = new Student_ProfileData()
                                    {
                                        MatricNumber = dataRow[0].ToString().Trim(),
                                        FirstName = dataRow[1].ToString().Trim(),
                                        LastName = dataRow[2].ToString().Trim(),
                                        Sex = dataRow[3].ToString().Trim(),
                                        Phone = dataRow[4].ToString().Trim(),
                                        Email = dataRow[5].ToString().Trim(),
                                        IsDeleted = false,
                                    };

                                    innerentities.Student_ProfileData.Add(newStudentInfo);
                                    innerentities.SaveChanges();
                                }
                                else
                                {
                                    try
                                    {
                                        studentData.FirstName = dataRow[1].ToString().Trim();
                                        studentData.LastName = dataRow[2].ToString().Trim();
                                        studentData.Sex = dataRow[3].ToString().Trim();
                                        studentData.Phone = dataRow[4].ToString().Trim();
                                        studentData.Email = dataRow[5].ToString().Trim();

                                        innerentities.Entry(studentData).State = EntityState.Modified;
                                        innerentities.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        innerentities = new Entities();
                                        ActivityLogger.Log(ex);
                                        TreatProcessingError(ex, dataRow.ItemArray);
                                    }
                                }
                            }
                            else
                            {
                                var newStudentInfo = new Student_ProfileData()
                                {
                                    MatricNumber = dataRow[0].ToString().Trim(),
                                    FirstName = dataRow[1].ToString().Trim(),
                                    LastName = dataRow[2].ToString().Trim(),
                                    Sex = dataRow[3].ToString().Trim(),
                                    Phone = dataRow[4].ToString().Trim(),
                                    Email = dataRow[5].ToString().Trim(),
                                    IsDeleted = false,
                                };

                                innerentities.Student_ProfileData.Add(newStudentInfo);
                                innerentities.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            ActivityLogger.Log(ex);
                            innerentities = new Entities();
                            TreatProcessingError(ex, dataRow.ItemArray);
                        }
                    }

                    returnData.Add(_returnDataPerTable);
                }

                FinalizeFileUpload(returnData, dataSet, notifyDestination);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
            }
        }

        private void ProcessStudentSchoolCustom(DataSet dataSet, bool forceReplace, string notifyDestination)
        {
            try
            {
                var innerentities = new Entities();
                var returnData = new List<List<string>>();

                foreach (DataTable table in dataSet.Tables)
                {
                    _returnDataPerTable = new List<string>();

                    foreach (DataRow dataRow in table.Rows)
                    {
                        var matricNumber = dataRow[1].ToString().Trim();

                        if (string.IsNullOrEmpty(matricNumber))
                            continue;

                        var studentData =
                            innerentities.Student_ProfileData.FirstOrDefault(
                                x => !x.IsDeleted && x.MatricNumber == matricNumber);

                        var names = ProcessStudentSchoolCustomNameSplit(dataRow[2].ToString());

                        try
                        {
                            if (studentData == null)
                            {
                                var newStudentInfo = new Student_ProfileData()
                                {
                                    MatricNumber = matricNumber,
                                    FirstName = names[0],
                                    LastName = names[1],
                                    Sex = dataRow[3].ToString().Trim(),
                                    BloodGroup = dataRow[5].ToString().Trim(),
                                    Phone = dataRow[6].ToString().Trim(),
                                    Email = dataRow[7].ToString().Trim(),
                                    IsDeleted = false,
                                };

                                innerentities.Student_ProfileData.Add(newStudentInfo);
                                innerentities.SaveChanges();

                                studentData = newStudentInfo;
                            }
                            else
                            {
                                if (forceReplace)
                                {
                                    studentData.FirstName = names[0];
                                    studentData.LastName = names[1];
                                    studentData.Sex = dataRow[3].ToString().Trim();
                                    studentData.Phone = dataRow[6].ToString().Trim();
                                    studentData.Email = dataRow[7].ToString().Trim();
                                    studentData.BloodGroup = dataRow[5].ToString().Trim();

                                    innerentities.Entry(studentData).State = EntityState.Modified;
                                    innerentities.SaveChanges();
                                }
                            }

                            var subSchoolId = ProcessSubSchoolEntry(dataRow[4].ToString().Trim());
                            var subSchooDepartmentlId = ProcessSubSchoolDepartmentEntry(subSchoolId, dataRow[0].ToString().Trim());

                            if (innerentities.Student_RegistrationData.Any(x =>
                                !x.IsDeleted && x.SubSchoolId == subSchoolId && x.AcademicPeriodId == 1 &&
                                x.SchoolId == 1 && x.SubSchoolDepartmentId == subSchooDepartmentlId &&
                                x.StudentId == studentData.Id))
                                continue;

                            innerentities.Student_RegistrationData.Add(new Student_RegistrationData()
                            {
                                AcademicPeriodId = 1,
                                DateRegistered = DateTime.Now,
                                IsDeleted = false,
                                SchoolId = 1,
                                StudentId = studentData.Id,
                                SubSchoolDepartmentId = subSchooDepartmentlId,
                                SubSchoolId = subSchoolId
                            });
                            innerentities.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            ActivityLogger.Log(ex);
                            innerentities = new Entities();
                            TreatProcessingError(ex, dataRow.ItemArray);
                        }
                    }

                    returnData.Add(_returnDataPerTable);
                }

                FinalizeFileUpload(returnData, dataSet, notifyDestination);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
            }
        }

        private string[] ProcessStudentSchoolCustomNameSplit(string rawName)
        {
            try
            {
                var nameSplit = rawName.Split(' ');
                var otherNames = string.Empty;

                for (var i = 1; i < nameSplit.Length; i++)
                {
                    otherNames += nameSplit[i] + " ";
                }

                return new[] {nameSplit[0].Trim(), $"{otherNames.Trim()}".Trim()};
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return new[] {"NA", "NA"};
            }
        }

        private int ProcessSubSchoolEntry(string subSchoolName)
        {
            try
            {
                var innerentities = new Entities();

                var subSchool =
                    innerentities.School_SubSchool.FirstOrDefault(x =>
                        !x.IsDeleted && x.SubSchoolName == subSchoolName) ?? new School_SubSchool();

                if (subSchool.Id != 0)
                    return subSchool.Id;

                subSchool.SubSchoolName = subSchoolName;
                innerentities.School_SubSchool.Add(subSchool);
                innerentities.SaveChanges();

                return subSchool.Id;
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return 0;
            }
        }

        private int ProcessSubSchoolDepartmentEntry(int subSchoolId, string subSchoolDepartmentName)
        {
            try
            {
                var innerentities = new Entities();

                var subSchoolDepartment =
                    innerentities.School_SubSchoolDepartment.FirstOrDefault(x =>
                        !x.IsDeleted && 
                        x.SubSchoolId == subSchoolId &&
                        x.SubSchoolDepartmentName == subSchoolDepartmentName) ??
                    new School_SubSchoolDepartment();

                if (subSchoolDepartment.Id != 0)
                    return subSchoolDepartment.Id;

                subSchoolDepartment.SubSchoolDepartmentName = subSchoolDepartmentName;
                subSchoolDepartment.SubSchoolId = subSchoolId;
                innerentities.School_SubSchoolDepartment.Add(subSchoolDepartment);
                innerentities.SaveChanges();

                return subSchoolDepartment.Id;
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return 0;
            }
        }

        private void FinalizeFileUpload(IReadOnlyCollection<List<string>> returnData, DataSet dataSet, string notifyDestination)
        {
            try
            {
                var messageBody =
                    System.IO.File.ReadAllText(
                        $"{HostingEnvironment.ApplicationPhysicalPath}Assets\\message\\fileprocesscomplete.html");
                messageBody = messageBody.Replace("{{file_name}}", dataSet.DataSetName);

                if (returnData.Count > 0)
                {
                    var errors = "";
                    foreach (var returnDatum in returnData)
                    {
                        foreach (var returnDatumItem in returnDatum)
                        {
                            errors += $"{returnDatumItem}<br />";
                        }
                    }
                    messageBody = messageBody.Replace("{{table_other_info}}", errors);
                }
                else
                    messageBody = messageBody.Replace("{{table_other_info}}", "No Notable Errors");

                Messaging.SendMail(notifyDestination, null, null, "File Processing Status", messageBody, null);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
            }
        }

        private void TreatProcessingError(Exception e, object data)
        {
            ActivityLogger.Log(e);
            ActivityLogger.Log("Trace on Failed Upload",
                JsonConvert.SerializeObject(data));
            _returnDataPerTable.Add("Error in Data");
            _returnDataPerTable.Add(JToken.Parse(JsonConvert.SerializeObject(data)).ToString(Formatting.Indented));
        }

        #endregion
    }
}