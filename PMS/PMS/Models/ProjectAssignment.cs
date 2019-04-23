using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class ProjectAssignment
    {
        public IEnumerable<project> projects { get; set; }
        public IEnumerable<user> mds { get; set; }
        public project project { get; set; }
        public projectAssign projectAs { get; set; }
    }
}