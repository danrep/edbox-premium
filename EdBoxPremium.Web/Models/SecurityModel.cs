using System.Web;
using EdBoxPremium.Data.InterchangeModels;

namespace EdBoxPremium.Web.Models
{
    public static class SecurityModel
    {
        public static bool IsUserSessionActive => HttpContext.Current.Session["UserInformation"] != null;

        public static void SetUserSession(AuthModel userInformation)
        {
            HttpContext.Current.Session.Add("UserInformation", userInformation);
        }

        public static AuthModel GetUserInSession
            => (AuthModel) HttpContext.Current.Session["UserInformation"];

        public static void ClearSession()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.RemoveAll();
        }
    }
}