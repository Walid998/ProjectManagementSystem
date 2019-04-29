using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Factory
{
    public class myFactory
    {
        public NotiInterface GetNoti(string typ)
        {
            if (typ.Equals("admin"))
            {
                return new Ad();
            }else if (typ.Equals("MD"))
            {
                return new MD();
            }else if (typ.Equals("MTL"))
            {
                return new MTL();
            }else if (typ.Equals("MT"))
            {
                return new MT();
            }else 
            {
                return new Customer();
            }
        }
    }
}