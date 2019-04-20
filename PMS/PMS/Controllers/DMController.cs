using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class DMController : Controller
    {
        pmsEcommerceEntities1 db = new pmsEcommerceEntities1();

        // GET: DM
        [Authorize(Roles = "MD")]
        public ActionResult Index()
        {           
            var projects = db.projects.Where(x => x.usrname.Equals(User.Identity.Name)).ToList();
            return View(projects);
        }


        //GEt project by id
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            project p = db.projects.Find(ID);
            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        //Delete project
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            project p = db.projects.Find(ID);
            db.projects.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}