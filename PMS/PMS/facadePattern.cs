using PMS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS
{
    public class facadePattern
    {
        static void Main(string[] args)
        {
            facade vehicle = new facade(new FeedbackController());
            vehicle.done();

            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(100);
                vehicle.failed();
            }
            
        }
    }
}