using EdBoxPremium.Core;
using EdBoxPremium.Data.InterchangeModels;
using System;
using System.Linq;
using System.Web.Mvc;
using EdBoxPremium.Data;

namespace EdBoxPremium.Web.Controllers
{
    public class ApiSettingsController : Controller
    {
        private readonly Entities _entities = new Entities();

        public JsonResult PullSettings()
        {
            try
            {
                var settings = _entities.System_Setting.Where(x => !x.IsDeleted).ToList();
                return Json(ResponseData.SendSuccessMsg(data: settings), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PullCourses()
        {
            try
            {
                var settings = _entities.School_Course.Where(x => !x.IsDeleted).ToList();
                return Json(ResponseData.SendSuccessMsg(data: settings), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PullAcademicData()
        {
            try
            {
                var schoolData = _entities.School_SubSchool.Where(x => !x.IsDeleted).ToList();
                return Json(ResponseData.SendSuccessMsg(data: new AcademicSetUpData()
                {
                    AcademicSetUpDatum = schoolData.Select(sd => new AcademicSetUpDatum()
                    {
                        SchoolSubSchool = sd,
                        SchoolSubSchoolDepartment = _entities.School_SubSchoolDepartment
                            .Where(ssd => ssd.SubSchoolId == sd.Id).ToList()
                    }).ToList()
                }), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }
    }
}