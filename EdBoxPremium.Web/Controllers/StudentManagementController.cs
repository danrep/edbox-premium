using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EdBoxPremium.Core;
using EdBoxPremium.Data;
using EdBoxPremium.Data.InterchangeModels;

namespace EdBoxPremium.Web.Controllers
{
    public class StudentManagementController : _BaseController
    {
        private Entities _db = new Entities();

        // GET: StudentManagement
        public ActionResult Index()
        {
            return View();
        }

        #region

        public JsonResult GetStudentProfiles(string query = "")
        {
            try
            {
                List<Student_ProfileData> students;

                if (string.IsNullOrEmpty(query))
                    students = _db.Student_ProfileData.Where(x => !x.IsDeleted).Take(100).ToList();
                else
                    students = _db.Student_ProfileData
                        .Where(x => !x.IsDeleted
                                    && (x.MatricNumber.Contains(query) ||
                                        x.FirstName.Contains(query) ||
                                        x.LastName.Contains(query) ||
                                        x.Sex.Contains(query) ||
                                        x.Phone.Contains(query) ||
                                        x.Email.Contains(query)))
                        .Take(100)
                        .ToList();

                return Json(new ResponseData
                {
                    Status = true,
                    Message = "Successful",
                    Data = students
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ActivityLogger.Log(ex);
                return Json(new ResponseData { Status = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}