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
        public IEnumerable<user> mt { get; set; }
        public IEnumerable<user> mtl { get; set; }
        public CreateProject cr { get; set; }
        public project project { get; set; }
        public projectAssign projectAs { get; set; }
        public IEnumerable<projectAssign> projectAsinss { get; set; }
    }
}