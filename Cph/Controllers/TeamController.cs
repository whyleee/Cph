using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cph.Data;
using Cph.Models;

namespace Cph.Controllers
{
    public class TeamController : Controller
    {
        public ActionResult Index()
        {
            var model = new TeamListModel();

            using (var db = new CphDb())
            {
                model.Members = db.Members.Include("SocialLinks.Service").ToList();
            }

            return View(model);
        }
    }
}