using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EdBoxPremium.Core;
using EdBoxPremium.Data.InterchangeModels;
using EdBoxPremium.Library;
using EdBoxPremium.Web.Models;

namespace EdBoxPremium.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LogIn(string username, string password)
        {
            var credential =
                Mocks.MockCredentials.FirstOrDefault(x =>
                    x.AccessCredential.Username == username);

            if (credential == null)
                return Json(ResponseData.SendFailMsg("You are not recognized here. Please contact the Administrator"),
                    JsonRequestBehavior.AllowGet);

            if (!Encryption.IsSaltEncryptValid(password, credential.AccessCredential.PasswordData,
                credential.AccessCredential.PasswordSalt))
                return Json(
                    ResponseData.SendFailMsg(
                        "Your password is incorrect. Please try again or contact the Administrator"),
                    JsonRequestBehavior.AllowGet);

            if (credential.AccessRoles.All(x => x.PermissionId != (int) RolePermissions.WebAdministrator))
                return Json(ResponseData.SendFailMsg("You are not authorised to use this Application"),
                    JsonRequestBehavior.AllowGet);

            SecurityModel.SetUserSession(credential);

            return Json(ResponseData.SendSuccessMsg("Your credentials have been accepted. Logging you in a moment."),
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            return RedirectToAction("Index");
        }
    }
}