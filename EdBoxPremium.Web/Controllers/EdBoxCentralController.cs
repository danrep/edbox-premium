using System.Linq;
using System.Web.Mvc;
using EdBoxPremium.Library;
using EdBoxPremium.Web.Models;

namespace EdBoxPremium.Web.Controllers
{
    public class EdBoxCentralController : _BaseController
    {
        // GET: EdBoxCentral
        public ActionResult Index()
        {
            return SecurityModel.GetUserInSession.AccessRoles.Any(x => x.PermissionId == (int) RolePermissions.RegOpr)
                ? RedirectToAction("Index", "AdminRegistration")
                : RedirectToAction("Index", "StudentManagement");
        }
    }
}