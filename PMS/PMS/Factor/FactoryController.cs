using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Factor
{
    public class FactoryController : Controller 
    {
        NotificationController x;
        string a;
        // GET: Factory


        public FactoryController (string a)
        {
            this.a = a;
        }
        public NotificationController Index()
        {
            if (a.Equals("admin"))
            {
               return x = new AController();
            }
            else 
            {
               return x = new DController();
            }
        }
    }
}