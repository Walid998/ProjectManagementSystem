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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            int y = db.users.Where(x => x.Username.Equals(User.Identity.Name)).Count();
           // int number =y.projectno;
            int q = db.qualifications.Where(x => x.usrname.Equals(User.Identity.Name)).Count();
           
            Ratio R = new Ratio();
            R.projectno = y;
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