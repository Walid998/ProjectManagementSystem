using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class ProjectController : Controller
    {
        pmsEcommerceEntities db = new pmsEcommerceEntities();
        // GET: Project
        public ActionResult ListProjects()
        {
            var pros = getProjects();
            return View(pros);
        }
        public IEnumerable<project> getProjects()
        {
            var pros = db.projects.ToList();
            return pros;
        }
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(project pro)
        {
            db.projects.Add(pro);
            db.SaveChanges();
            return RedirectToAction("ListProjects");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var pro = getProjects().SingleOrDefault(y => y.id == id);
            return View(pro);
        }

        [HttpGet]
        public ActionResult DeleteProject(int id)
        {
            var pro = getProjects().SingleOrDefault(y => y.id == id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult DeleteProject(project pro)
        {
            var pros = getProjects().SingleOrDefault(y => y.id == pro.id);
            db.projects.Remove(pros);
            db.SaveChanges();
            return RedirectToAction("ListProjects");
        }

    }
}