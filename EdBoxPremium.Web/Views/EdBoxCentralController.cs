using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EdBoxPremium.Web.Controllers;

namespace EdBoxPremium.Web.Views
{
    public class EdBoxCentralController : _BaseController
    {
        // GET: EdBoxCentral
        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("Index", "StudentManagement");
        }
    }
}