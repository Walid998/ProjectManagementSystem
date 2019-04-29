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
        int a;
        // GET: Factory


        public FactoryController (int a)
        {
            this.a = a;
        }
        public void Index()
        {
            if (a==1)
            {
                x = new BController();
            }
            else
            {
                x = new AController();
            }
        }
    }
}