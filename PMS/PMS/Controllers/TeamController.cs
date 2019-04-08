using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class TeamController : Controller
    {
        pmsEcommerceEntities db = new pmsEcommerceEntities();
        // GET: team
        
        public ActionResult add_team()
        {
            return View();
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
            return RedirectToAction("getTeams");
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

    }
}