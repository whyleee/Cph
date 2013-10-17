using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cph.Aids;
using Cph.Data;
using Cph.Hubs;
using Cph.Models;
using Microsoft.AspNet.SignalR;

namespace Cph.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly CphDb db = new CphDb();

        public ActionResult Index()
        {
            var model = new ProjectListModel
                {
                    Projects = db.Projects.OrderByDescending(p => p.Started).ToList()
                };
            return View(model);
        }

        public ActionResult Details(string name)
        {
            var project = GetProject(name);

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        public ActionResult Edit(string name)
        {
            var project = GetProject(name);

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        public ActionResult EditForm(string name)
        {
            var project = GetProject(name);

            if (project == null)
            {
                return HttpNotFound();
            }

            return PartialView(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();

                // update other clients
                var @lockHub = GlobalHost.ConnectionManager.GetHubContext<LockHub>();
                @lockHub.Clients.All.update(project.GetEntityId());

                return RedirectToAction("Details", new {name = project.Name});
            }

            return View(project);
        }

        private Project GetProject(string name)
        {
            return db.Projects.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}