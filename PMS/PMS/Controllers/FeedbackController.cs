using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    
    public class FeedbackController : Controller, IFeedback
    {
        pmsEcommerceEntities1 db = new pmsEcommerceEntities1();
        public bool Running { get; private set; }
        IFeedback feed = null;
        public FeedbackController() : this(new feed())
        {

        }

        public FeedbackController(IFeedback feed)
        {
            this.feed = feed;
        }

        public void error()
        {

            Running = false;
            Console.WriteLine(" not feedback send ");
        }


        [HttpGet]
        public ActionResult send()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult send(feedback a)
        {
            if (ModelState.IsValid)
            {
                feed.send(a);
            }
            return RedirectToAction("send");
        }

        

        public ActionResult welcome()
        {   
            return View();
        }

        void IFeedback.send(feedback a)
        {
            throw new NotImplementedException();
        }
        
    }
}