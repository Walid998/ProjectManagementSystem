using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Factory
{
    public class Ad : NotiInterface
    {
        public string NotiType()
        {
            var qu = @"SELECT [NotificationId],[Status],[Message],[ExtraColumn] FROM [dbo].[tbl_Notification] where  ExtraColumn='admin'";

            return Models.NotificaionService.GetNotification(qu);
        }
    }
}