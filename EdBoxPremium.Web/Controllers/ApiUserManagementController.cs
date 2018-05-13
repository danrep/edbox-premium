using EdBoxPremium.Core;
using EdBoxPremium.Data.InterchangeModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EdBoxPremium.Data;

namespace EdBoxPremium.Web.Controllers
{
    public class ApiUserManagementController : Controller
    {
        private readonly Entities _entities = new Entities();

        // GET: RemoteStudentManagement
        public JsonResult PullUsers(int done=0)
        {
            try
            {
                //var accessCredentials = _entities.Administration_AccessCredential.Where(x => !x.IsDeleted)
                //    .OrderBy(x=> x.Id)
                //    .Skip(done)
                //    .Take(100)
                //    .ToList();

                var accessCredentials = Mocks.MockCredentials
                    .OrderBy(x => x.AccessCredential.Id)
                    .Skip(done)
                    .Take(100)
                    .ToList();

                var accessCredentialData = accessCredentials.Select(x => new AuthModel()
                {
                    AccessCredential = x.AccessCredential,
                    AccessRoles = x.AccessRoles
                }).ToList();

                return Json(ResponseData.SendSuccessMsg(data: accessCredentialData), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PullUserId(int id)
        {
            try
            {
                var user = Mocks.MockCredentials.FirstOrDefault(x => x.AccessCredential.Id == id);

                return Json(
                    user == null
                        ? ResponseData.SendFailMsg("User Does not Exist")
                        : ResponseData.SendSuccessMsg(data: user), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult PullUserUsername(string username)
        {
            try
            {
                var user = Mocks.MockCredentials.FirstOrDefault(x => x.AccessCredential.Username == username);

                return Json(
                    user == null
                        ? ResponseData.SendFailMsg("User Does not Exist")
                        : ResponseData.SendSuccessMsg(data: user), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return Json(ResponseData.SendExceptionMsg(e), JsonRequestBehavior.AllowGet);
            }
        }
    }
}