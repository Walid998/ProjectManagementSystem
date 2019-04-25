using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Controllers
{
   public interface IFeedback
    {
        bool Running { get; }
        void send();
        void error();
    }
}
