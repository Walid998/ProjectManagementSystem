using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Models;

namespace PMS.Controllers

{
    public class DiagramController : Controller
    {

        pmsEcommerceEntities1 db = new pmsEcommerceEntities1();
        // GET: Diagram
        [Authorize(Roles =("DM , MTL , MT"))]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            int y;
            Ratio R = new Ratio();
            if (User.IsInRole("MD"))
            {
                y = db.projectAssigns.Where(x => x.name_dm.Equals(User.Identity.Name)).Count();
                R.projectno = y;
            }
            else if (User.IsInRole("MTL"))
            {
                y = db.CreateProjects.Where(x => x.leader_name.Equals(User.Identity.Name)).Count();
                R.projectno = y;
            }

            else
            {
                y = db.teams.Where(x => x.member_name.Equals(User.Identity.Name)).Count();
                R.projectno = y;
            }
           // int number =y.projectno;
            int q = db.qualifications.Where(x => x.usrname.Equals(User.Identity.Name)).Count();
           
            R.qualification = q;
            return Json(R, JsonRequestBehavior.AllowGet);
        }

        public class Ratio
        {
            public int projectno { get; set; }
            public int qualification { get; set; }
        }
    }
}