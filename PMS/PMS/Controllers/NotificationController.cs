using PMS.Factor;
using PMS.Factory;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PMS.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }// GET: Notification
        public ActionResult Test()
        {
            return View();
        }

        public JsonResult GetNotification()
        {
            try
            {
                myFactory mf = new myFactory();

                string[] x = Roles.GetRolesForUser(User.Identity.Name);
                NotiInterface No = mf.GetNoti(x[0]);

                return Json(No.NotiType(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}