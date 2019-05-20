using EdBoxPremium.Core;
using EdBoxPremium.Data.InterchangeModels;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using EdBoxPremium.Data;

namespace EdBoxPremium.Web.Controllers
{
    public class ApiStudentManagementController : Controller
    {
        private readonly Entities _entities = new Entities();

        // GET: RemoteStudentManagement
        public JsonResult PullStudents(int done = 0)
        {
            try
            {
                var students = _entities.Student_ProfileData.Where(x => !x.IsDeleted)
                    .OrderBy(x => x.Id)
                    .Skip(done)
                    .Take(50)
                    .ToList();

                return Json(ResponseData.SendSuccessMsg(data: students), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PullStudentsCompleteData(int done = 0)
        {
            try
            {
                var students = _entities.Student_ProfileData.Where(x => !x.IsDeleted)
                    .OrderBy(x => x.Id)
                    .Skip(done)
                    .Take(50)
                    .ToList();

                var studentData = students.Select(GetStudent).ToList();

                return Json(ResponseData.SendSuccessMsg(data: studentData), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PullStudentById(int id)
        {
            try
            {
                var student = _entities.Student_ProfileData.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
                if (student == null)
                    return Json(ResponseData.SendFailMsg("Matric Number Does not Exist"), JsonRequestBehavior.AllowGet);

                var studentData = GetStudent(student);

                return Json(ResponseData.SendSuccessMsg(data: studentData), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PullStudentDataByMatricNumber(string matricNumber)
        {
            try
            {
                var student = _entities.Student_ProfileData.FirstOrDefault(x => !x.IsDeleted && x.MatricNumber == matricNumber);
                if (student == null)
                    return Json(ResponseData.SendFailMsg("Matric Number Does not Exist"), JsonRequestBehavior.AllowGet);

                var studentData = GetStudent(student);

                return Json(ResponseData.SendSuccessMsg(data: studentData), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult TagStudent(string matricNumber, string tagId)
        {
            try
            {
                var student = _entities.Student_ProfileData.FirstOrDefault(x => !x.IsDeleted && x.MatricNumber == matricNumber);
                if (student == null)
                    return Json(ResponseData.SendFailMsg("Matric Number Does not Exist"), JsonRequestBehavior.AllowGet);

                student.TagId = tagId;
                _entities.Entry(student).State = EntityState.Modified;
                _entities.SaveChanges();

                return Json(ResponseData.SendSuccessMsg(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UnTagStudent(string tagId)
        {
            try
            {
                var student = _entities.Student_ProfileData.FirstOrDefault(x => !x.IsDeleted && x.TagId == tagId);
                if (student == null)
                    return Json(ResponseData.SendFailMsg("Tag Does not Exist on the Server"), JsonRequestBehavior.AllowGet);

                student.TagId = null;
                _entities.Entry(student).State = EntityState.Modified;
                _entities.SaveChanges();

                return Json(ResponseData.SendSuccessMsg(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        private StudentCompleteData GetStudent(Student_ProfileData studentProfileData)
        {
            try
            {
                var location = System.Web.Hosting.HostingEnvironment.MapPath("~/PassportPictureFiles/Students") ?? "";
                var pictureFileInfo = new FileInfo(Path.Combine(location, $"{CleanDataForFileName(studentProfileData.MatricNumber)}.jpg"));

                if (!pictureFileInfo.Exists)
                    pictureFileInfo = new FileInfo(Path.Combine(location, studentProfileData.MatricNumber
                                                                              .Replace("-", "0")
                                                                              .Replace("_", "0")
                                                                              .Replace("/", "0")
                                                                              .Replace("\\", "0") + ".png"));

                if (pictureFileInfo.Exists)
                    studentProfileData.Picture =
                        Convert.ToBase64String(System.IO.File.ReadAllBytes(pictureFileInfo.FullName));

                return new StudentCompleteData()
                {
                    StudentProfileData = studentProfileData,
                    StudentData = _entities.Student_RegistrationData
                        .Where(x => !x.IsDeleted && x.StudentId == studentProfileData.Id)
                        .Select(studentRegData => new StudentData()
                        {
                            StudentRegistrationData = studentRegData,
                            StudentCourseRegistration = _entities.Student_CourseRegistration
                                .Where(course =>
                                    !course.IsDeleted &&
                                    course.AcademicPeriodId == studentRegData.AcademicPeriodId &&
                                    course.SchoolIdId == studentRegData.SchoolId &&
                                    course.SubSchoolId == studentRegData.SubSchoolId &&
                                    course.SubSchoolDepartmentId == studentRegData.SubSchoolDepartmentId)
                                .ToList()
                        }).ToList()
                };
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return null;
            }
        }

        private string CleanDataForFileName(string raw)
        {
            return raw.Replace('/', '0').Replace('\\', '0').Replace('@', '0').Replace('#', '0');
        }
    }
}