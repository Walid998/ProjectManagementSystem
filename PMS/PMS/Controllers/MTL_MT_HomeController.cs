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
        // [Authorize (Roles = "MTL,TL")]

        public ActionResult Index()
        {
            var p = db.projects.ToList();
            return View(p);

        }
    }
}