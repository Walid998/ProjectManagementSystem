using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
        /*********************************************/
        /*************Manage_project_to_create*************/
        public ActionResult manage_project()
        {
            return View();
        }
        [HttpPost]
        public ActionResult manage_project(CreateProject c)
        {
            db.CreateProjects.Add(c);
            db.SaveChanges();
            return RedirectToAction("ListManageProject");
        }
        public ActionResult ListManageProject()
        {
            var M = getManageProjects();
            return View(M);
        }
        public IEnumerable<CreateProject> getManageProjects()
        {
            var M = db.CreateProjects.ToList();
            return M;
        }
        [HttpGet]
        public ActionResult Details_project(int id)
        {
            var M = getManageProjects().SingleOrDefault(y => y.id == id);
            return View(M);
        }

        [HttpGet]
        public ActionResult DeleteManageProject(int id)
        {
            var M = db.CreateProjects.SingleOrDefault(y => y.id == id);
            return View(M);
        }
        [HttpPost]
        public ActionResult DeleteManageProject(CreateProject pro)
        {
            var M = db.CreateProjects.SingleOrDefault(y => y.id == pro.id);
            db.CreateProjects.Remove(M);
            db.SaveChanges();
            return RedirectToAction("ListManageProject");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateProject pro = db.CreateProjects.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Update = db.CreateProjects.Find(id);
            if (TryUpdateModel(Update, "",
               new string[] { "pro_name", "strt_date", "end_date","stat","price","leader_name" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("ListManageProject");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(Update);
        }

    }
}