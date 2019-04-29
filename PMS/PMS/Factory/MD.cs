using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.Factory
{
    public class MD : NotiInterface
    {
        public string NotiType()
        {
            //var qu = @"SELECT [NotificationId],[Status],[Message],[ExtraColumn] FROM [dbo].[tbl_Notification]  where not ( ExtraColumn='admin' and ExtraColumn='MD')";
            var qu = @"SELECT [NotificationId],[Status],[Message],[ExtraColumn] FROM [dbo].[tbl_Notification]  where ExtraColumn='MD'";

            return Models.NotificaionService.GetNotification(qu);
        }
    }
}