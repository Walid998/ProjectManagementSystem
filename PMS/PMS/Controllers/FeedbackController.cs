using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class FeedbackController : Controller, IFeedback
    {
        public bool Running { get; private set; }

        public void error()
        {

            Running = false;
            Console.WriteLine(" not feedback send ");
        }


        public ActionResult send()
        {
            Running = true;
            Console.WriteLine(" successful send ");
            return View();
        }
    }
}