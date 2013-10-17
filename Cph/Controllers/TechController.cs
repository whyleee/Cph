using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cph.Controllers
{
    public class TechController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReleaseNotes()
        {
            return View();
        }
    }
}