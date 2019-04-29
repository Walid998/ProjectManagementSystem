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
        pmsEcommerceEntities1 db = pmsEcommerceEntities1.getInstance();

        // GET: DM
        [Authorize(Roles = "MD")]
        public ActionResult Index()
        {           
            var projects = db.projectAssigns.Where(x => x.name_dm.Equals(User.Identity.Name)).ToList();
            return View(projects);
        }


        //GEt projectAssign by id
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            projectAssign p = db.projectAssigns.Find(ID);
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
            projectAssign p = db.projectAssigns.Find(ID);
            db.projectAssigns.Remove(p);

            project x = db.projects.Find(ID);
            x.stat = "to do";
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}