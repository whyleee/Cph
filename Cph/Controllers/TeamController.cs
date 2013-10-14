using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cph.Data;

namespace Cph.Controllers
{
    public class TeamController : Controller
    {
        private readonly CphDb db = new CphDb();

        public ActionResult Index()
        {
            var team = db.Teams.First(t => t.Name == "CPH Alpha Team");

            return View(team);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}