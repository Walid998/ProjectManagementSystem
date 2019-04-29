using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Factor
{
    public class BController : Controller , NotificationController
    {
        // GET: B
        public ActionResult Index()
        {
            return View();
        }

        void NotificationController.Get_Query()
        {
            String x = Models.NotificaionService.GetNotification();
        }
    }
}