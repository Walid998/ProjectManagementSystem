using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class CurrentPMTL
    {
        public IEnumerable<team> tms { get; set; }
        public IEnumerable<CreateProject> CurPros { get; set; }
    }
}