using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class TeamAssign
    {
        public IEnumerable<project> projects { get; set; }
        public IEnumerable<user> mt { get; set; }
        public team t { get; set; }
    }
}