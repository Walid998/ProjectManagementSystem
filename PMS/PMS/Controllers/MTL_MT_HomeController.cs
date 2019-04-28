using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class MTL_MT_HomeController : Controller
    {
        pmsEcommerceEntities1 db = new pmsEcommerceEntities1();

        // GET: MTL_MT_Home

         [Authorize (Roles = "MTL,MT")]

        public ActionResult Index()
        {
            var p = db.projects.Where(x => x.stat == "to do").ToList();
            return View(p);
        }
        /*
        public ActionResult List_MTL()
        {
            var p = db.CreateProjects.Where(x => x.leader_name.Equals(User.Identity.Name)).ToList();
            return View(p);
        }


        public ActionResult List_MT()
        {
            var p = db.teams.Where(x => x.member_name.Equals(User.Identity.Name)).ToList();
            return View(p);
        }


        //Leader Delete Project
        //GEt projectAssign by id
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateProject p = db.CreateProjects.Find(ID);
            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        //Delete projectAssign from MD & Project => To do
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            CreateProject p = db.CreateProjects.Find(ID);
            db.CreateProjects.Remove(p);

            team x = db.teams.Find(ID);
            x.leader_name = " ";
            db.SaveChanges();
            return RedirectToAction("List_MTL");
        }

    */

    }
}