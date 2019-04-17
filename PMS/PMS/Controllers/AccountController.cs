using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PMS.Controllers
{
    public class AccountController : Controller
    {
        pmsEcommerceEntities1 db = new pmsEcommerceEntities1();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(user model, string url)
        {
            try
            {
                var dataItem = db.users.Where(x => x.Username == model.Username && x.Password == model.Password).First();
                if (dataItem != null)
                {
                    FormsAuthentication.SetAuthCookie(dataItem.Username, false);
                    if (Url.IsLocalUrl(url) && url.Length > 1 && url.StartsWith("/")
                        && !url.StartsWith("//") && !url.StartsWith("/\\"))
                    {
                        return Redirect(url);
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user/pass");
                    return View();
                }
            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Invalid username or password!');window.location.replace('Login');</script>");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(user reg,string name)
        {
            reg.Role = "customer";
            db.users.Add(reg);
            db.SaveChanges();
            return View("Index");
        }
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("About", "Home");
        }
    }
}