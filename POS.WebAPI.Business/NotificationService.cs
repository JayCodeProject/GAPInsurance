using System;
using System.Collections.Generic;
using POS.WebAPI.Entity;
using POS.WebAPI.Extender;
using POS.WebAPI.Data.Dapper;

namespace POS.WebAPI.Business
{
    public class NotificationService : INotificationService
    {
        private NotificationRepository _NotificationRepository;
        private LogRepository _LogRepository;

        public NotificationService(NotificationRepository NotificationRepository, LogRepository LogRepository)
        {
            _NotificationRepository = NotificationRepository;
            _LogRepository = LogRepository;
        }

        public IEnumerable<Notification> GetNotificationByUse(UserAccount user)
        {
            IEnumerable<Notification> notificationList = null;
            var startTime = DateTime.Now;
            var process = new ProcessEvent();

            var jsonParameters = new
            {
                p_user_id = user.Id,
                p_cat_notification = user.NotificationType,
                p_created_user = user.CreatedUser,
                p_company_id = user.CompanyId
            };


            try
            {
                process.company = user.CompanyName;
                process.procName = "Proc_GetNotification";
                process.parameters = jsonParameters.SerializeObject();
                process.createdUser = user.CreatedUser;
                process.beginTime = startTime;
                process.endTime = DateTime.Now;

                notificationList = _NotificationRepository.GetNotificationByUser(user);

                process.result = notificationList.SerializeObject();
            }
            catch (Exception ex)
            {
                process.errorMsg = ex.Message;
            }
            finally
            {
                _LogRepository.SaveLog(process);
            }

            return notificationList;

        }
    }
}
