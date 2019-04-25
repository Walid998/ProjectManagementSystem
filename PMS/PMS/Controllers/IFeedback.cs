using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PMS.Controllers
{
   public interface IFeedback
    {
        bool Running { get; }
        ActionResult send();
        void error();
    }
}
