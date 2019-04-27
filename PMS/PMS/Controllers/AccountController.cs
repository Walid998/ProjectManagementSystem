using PMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
       /* public ActionResult Register(user reg, string name)
        {
            if (reg.Username != null)
            {
                reg.Role = "customer";
                //string fileName = Path.GetFileNameWithoutExtension(reg.Upload.FileName);
                string extension = Path.GetExtension(reg.Upload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                reg.photo = fileName;
                reg.Upload.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images"), fileName));
                db.users.Add(reg);
                db.SaveChanges();
            }
            var result = "Successfully Added";
            return Json(result, JsonRequestBehavior.AllowGet);

        }*/

        [Authorize]
        public ActionResult SignOut()
        {
            
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();


            return RedirectToAction("About", "Home");
        }

        public PartialViewResult ViewProf()
        {
            var item = db.users.SingleOrDefault(x => x.Username == User.Identity.Name);

            return PartialView(item);
        }


    }
}