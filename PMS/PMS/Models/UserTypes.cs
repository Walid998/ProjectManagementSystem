using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class UserTypes
    {
        public user users { get; set; }
        public IEnumerable<userType> UsrTypes { get; set; }
        
    }
}