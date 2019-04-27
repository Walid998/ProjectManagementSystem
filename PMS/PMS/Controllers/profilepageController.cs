using PMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PMS.Controllers
{
    public class profilepageController : Controller
    {
        pmsEcommerceEntities1 db = new pmsEcommerceEntities1();
        // GET: profilepage
        /*image*/
        /*public ActionResult Index()
         {
             string displayimg = (string)Session["Username"];
             string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
             SqlConnection sqlconn = new SqlConnection(mainconn);
             string sqlquery = "select photo from [dbo].[MVCregUser] where Username'" + displayimg + "'";
             sqlconn.Open();
             SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
             sqlcomm.Parameters.AddWithValue("Username",Session["Username"].ToString());
             SqlDataReader sdr = sqlcomm.ExecuteReader();
             if (sdr.Read())
             {
                 string s = sdr["photo"].ToString();
                 ViewData["Img"] = s;

             }
             sqlconn.Close();
             return View();
         }*/
        [HttpGet]
        public ActionResult Details(Login model)
        {
            var profile = db.users.SingleOrDefault(x => x.Username.Equals(User.Identity.Name));
            return View(profile);
        }
        [HttpGet]
        public ActionResult DetailUser()
        {
            var profile = db.users.SingleOrDefault(x => x.Username.Equals(User.Identity.Name));
            return View(profile);
        }
        [HttpGet]
        public ActionResult _Customer_Trainee()
        {
            var profile = db.users.SingleOrDefault(x => x.Username.Equals(User.Identity.Name));
            return View(profile);
        }

        [HttpPost]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            user b = db.users.Find(id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Edit(user use)
        {

            if (ModelState.IsValid)
            {

                db.Entry(use).State = EntityState.Modified;

                db.SaveChanges();

            }

            return RedirectToAction("DetailUser");

        }
        [HttpGet]
        public ActionResult Edit_c(int? id)
        {
            user b = db.users.Find(id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Edit_c(user use)
        {

            if (ModelState.IsValid)
            {

                db.Entry(use).State = EntityState.Modified;

                db.SaveChanges();

            }

            return RedirectToAction("Details");

        }
        public PartialViewResult ProfInfo()
        {
            var item = db.users.SingleOrDefault(x => x.Username == User.Identity.Name);
            
            return PartialView("ViewProf",item);
        }

        

    }
}
