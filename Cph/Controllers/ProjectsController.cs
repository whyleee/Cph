﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cph.Data;
using Cph.Models;

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
            var project = db.Projects.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}