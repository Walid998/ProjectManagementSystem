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
    public class TeamController : Controller
    {
        pmsEcommerceEntities1 db = pmsEcommerceEntities1.getInstance();
        // GET: team

        public ActionResult add_team()
        {
            var pros = getProjects().Where(x => x.stat == "to do");
            
            var mts = getDm().Where(x => x.Role == "MT");
            team PA = new team
            {
                
                mt = mts,
                projects = pros

            };
            return View(PA);
        }
        public IEnumerable<user> getDm()
        {
            var usr = db.users.ToList();
            return usr;
        }
        public ActionResult ListTeam()
        {
            var t = getTeams();
            return View(t);
        }
        public IEnumerable<team> getTeams()
        {
            var t = db.teams.ToList();
            return t;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add_team(team o)
        {
            db.teams.Add(o);
            db.SaveChanges();
            return RedirectToAction("ListTeam");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var t = getTeams().SingleOrDefault(y => y.id == id);
            return View(t);
        }
        public ActionResult Deleteteam()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "MTL")]
        public ActionResult Deleteteam(int id)
        {
            var t = getTeams().SingleOrDefault(y => y.id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult Deleteteam(team o)
        {
            var t = getTeams().SingleOrDefault(y => y.id == o.id);
            db.teams.Remove(t);
            db.SaveChanges();
            return RedirectToAction("ListTeam");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            team t = db.teams.Find(id);
            if (t == null)
            {
                return HttpNotFound();
            }
            return View(t);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditTeam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Update = db.teams.Find(id);
            if (TryUpdateModel(Update, "",
               new string[] { "leader_name","member_name" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("ListTeam");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(Update);
        }
        public IEnumerable<project> getProjects()
        {
            var pros = db.projects.ToList();
            return pros;
        }


    }
}
