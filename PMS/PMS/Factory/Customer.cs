using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Factory
{
    
    public class Customer : NotiInterface
    {

        public string NotiType()
        {
            var qu = @"SELECT [NotificationId],[Status],[Message],[ExtraColumn] FROM [dbo].[tbl_Notification]  where ExtraColumn='admin' and ExtraColumn='MD'";

            return Models.NotificaionService.GetNotification(qu);
        }
    }
}