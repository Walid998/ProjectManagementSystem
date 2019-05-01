using System;
using PMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class HomeController : Controller
    {
        pmsEcommerceEntities1 db = pmsEcommerceEntities1.getInstance();
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
            return View();
        }

        public ActionResult SaveToDb(contact model)
        {
            try
            {
                contact con = new contact();
                con.c_name = model.c_name;
                con.email = model.email;
                con.subjct = model.subjct;
                con.msage = model.msage;
                con.spam_flag = 0;

                db.contacts.Add(con);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Display()
        {
            IQueryable<contact> model = db.contacts.Where(m => m.spam_flag == 0);
            return View(model);
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