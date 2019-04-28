using PMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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
        public ActionResult Register(user reg, string name)
        {
            if (reg.Username != null)
            {
                reg.Role = "customer";
                string fileName = Path.GetFileNameWithoutExtension(reg.Upload.FileName);
                string extension = Path.GetExtension(reg.Upload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                reg.photo = fileName;
                reg.Upload.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images"), fileName));
                db.users.Add(reg);
                db.SaveChanges();
            }
            var result = "Successfully Added";
            return Json(result, JsonRequestBehavior.AllowGet);

        }

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
        /**************************************************/
        //
        //      FORGET PASSWORD
        //
        //                                                                      
        /***************************************************/
        private static string confirmCode;
        private static string GuestEmail;


        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(string receiver)
        {
            if (getEmails(receiver))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var senderEmail = new MailAddress("younissaiedfcih@gmail.com", "PMS E-commerce");
                        var receiverEmail = new MailAddress(receiver, "Receiver");
                        GuestEmail = receiver;
                        var password = "younis20172018";
                        var sub = "Reset Your Password";
                        confirmCode = RandomString(8, true);
                        var body = "use this code: " + confirmCode;
                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(senderEmail.Address, password)
                        };
                        using (var mess = new MailMessage(senderEmail, receiverEmail)
                        {
                            Subject = sub,
                            Body = body
                        })
                        {
                            smtp.Send(mess);
                        }
                        return RedirectToAction("ResetCodeConfirmation");
                    }
                }
                catch (Exception)
                {
                    ViewBag.Error = "Some Error";
                }
            }
            else return RedirectToAction("NotMatch");
            return View();
        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private bool getEmails(String email)
        {
            var usr = db.users.Where(y => y.email == email).SingleOrDefault();
            if (usr != null)
                return true;
            else
                return false;
        }

        public ActionResult ResetCodeConfirmation()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ResetCodeConfirmation(string code)
        {
            var usr = db.users.Where(y => y.email == GuestEmail).SingleOrDefault();

            if (confirmCode.Equals(code))
            {
                // get into as 'wating user' until change the password
                return RedirectToAction("UpdatePassword/" + usr.id + "");
            }
            else { return RedirectToAction("InvalidCode"); }

        }


        public ActionResult NotMatch()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UpdatePassword(int id)
        {
            var us = db.users.SingleOrDefault(y => y.id == id);
            return View(us);
        }
        [HttpPost]
        public ActionResult UpdatePassword(user usr)
        {
            var us = db.users.SingleOrDefault(u => u.id == usr.id);
            us.Password = usr.Password;
            db.SaveChanges();
            return RedirectToAction("ListUsers");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var us = db.users.SingleOrDefault(y => y.id == id);
            return View(us);
        }

        public ActionResult InvalidCode()
        {
            return View();
        }


    }
}