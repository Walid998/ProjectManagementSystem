using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (User.IsInRole("MTL"))
            {
                var p = db.CreateProjects.Where(x => x.leader_name.Equals(User.Identity.Name)).ToList();
                return View(p);
            }

            //User is MT
            else
            {
                var p = db.CreateProjects.Where(x => x.leader_name.Equals(User.Identity.Name)).ToList();
                return View(p);
            }
        }
    }
}