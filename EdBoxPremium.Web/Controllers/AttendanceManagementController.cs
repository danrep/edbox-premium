using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdBoxPremium.Web.Controllers
{
    public class AttendanceManagementController : _BaseController
    {
        // GET: AttendanceManagement
        public ActionResult Index()
        {
            return View();
        }
    }
}