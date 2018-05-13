using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EdBoxPremium.Web.Models;

namespace EdBoxPremium.Web.Controllers
{
    public class _BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext); Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionDesc = (ReflectedActionDescriptor)filterContext.ActionDescriptor;

            if (SecurityModel.IsUserSessionActive)
                return;

            filterContext.Result = RedirectToAction("Index", "Home", new {area = ""});
            SecurityModel.ClearSession();
            return;
        }
    }
}