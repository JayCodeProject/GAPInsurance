using POS.WebAPI.Entity;
using POS.WebAPI.Infraestructure;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace POS.WebAPI.Data.Dapper
{
    public class NotificationRepository
    {
        private IConnectionFactory _connectionFactory;

        public NotificationRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Notification> GetNotificationByUser(UserAccount user)
        {
            var procedure = "dbo.Proc_GetNotification";
            IEnumerable<Notification> notificationList = null;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                notificationList = connection.Query<Notification>(
                                                                  procedure,
                                                                  param: new
                                                                  {
                                                                      p_user_id = user.Id,
                                                                      p_cat_notification = user.NotificationType,
                                                                      p_created_user = user.CreatedUser
                                                                  },
                                                                   commandType: CommandType.StoredProcedure
                                                                  );
            }

            return notificationList;
        }

    }
}
