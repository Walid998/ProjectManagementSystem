using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Factor
{
    public class DController : Controller , NotificationController
    {
  
        void NotificationController.Get_Query()
        {
            var qu = @"SELECT [NotificationId],[Status],[Message],[ExtraColumn] FROM [dbo].[tbl_Notification] where ExtraColumn='admin'";

            String x = Models.NotificaionService.GetNotification(qu);
        }
    }
}