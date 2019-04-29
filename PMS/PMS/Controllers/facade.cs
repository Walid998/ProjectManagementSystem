using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Controllers
{
    public class facade
    {
        pmsEcommerceEntities1 db = new pmsEcommerceEntities1();
        private IFeedback Send;
        public facade()
        {
            Send = new feed();
        }
        public void attach(feedback a)
        {
            Send.send(a);
        }
    }
}