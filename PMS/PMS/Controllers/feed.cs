using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMS.Models;
namespace PMS.Controllers
{
    public class feed : IFeedback
    {
        pmsEcommerceEntities1 db = new pmsEcommerceEntities1();
        
         

        public bool Running => throw new NotImplementedException();

        

        
        public void send()
        { }
        public void send(feedback a)
        {
            db.feedbacks.Add(a);
            db.SaveChanges();
        }

        public void error()
        {
            throw new NotImplementedException();
        }
    }
}