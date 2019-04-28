using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PMS.Models; 

namespace PMS.Controllers
{
   public interface IFeedback 
    {
        bool Running { get; }
        void send(feedback a);
        void error();
    }
}
