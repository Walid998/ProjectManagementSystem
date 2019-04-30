using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        /*                      TEST LAYOUTS                        */
        public ActionResult Lay_Admin()
        {

            return View();
        }
        public ActionResult Lay_Trainee()
        {

            return View();
        }
        public ActionResult Lay_Home()
        {

            return View();
        }
    }
}