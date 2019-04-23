using PMS.Hubs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PMS.Models
{
    public class NotificaionService
    {

        static readonly string connString = @"data source=DESKTOP-EOBV2JQ\SQLEXPRESS;initial catalog=pmsEcommerce;integrated security=True";

        internal static SqlCommand command = null;
        internal static SqlDependency dependency = null;


        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <returns></returns>
        public static string GetNotification()
        {
            try
            {

                var messages = new List<tbl_Notification>();
                using (var connection = new SqlConnection(connString))
                {

                    connection.Open();
                    //// Sanjay : Alwasys use "dbo" prefix of database to trigger change event
                    using (command = new SqlCommand(@"SELECT [NotificationId],[Status],[Message],[ExtraColumn] FROM [dbo].[tbl_Notification]", connection))
                    {
                        command.Notification = null;

                        if (dependency == null)
                        {
                            dependency = new SqlDependency(command);
                            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                        }

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new tbl_Notification
                            {

                                NotificationId = (int)reader["NotificationId"],
                                Status = reader["Status"] != DBNull.Value ? (string)reader["Status"] : "",
                                Message = reader["Message"] != DBNull.Value ? (string)reader["Message"] : "",
                                ExtraColumn = reader["ExtraColumn"] != DBNull.Value ? (string)reader["ExtraColumn"] : ""
                            });
                        }
                    }

                }
                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(messages);
                return json;

            }
            catch (Exception ex)
            {

                return null;
            }


        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (dependency != null)
            {
                dependency.OnChange -= dependency_OnChange;
                dependency = null;
            }
            if (e.Type == SqlNotificationType.Change)
            {
                MyNewHub.Send();
            }
        }

    }
}