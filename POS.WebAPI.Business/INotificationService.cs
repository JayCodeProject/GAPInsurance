using POS.WebAPI.Entity;
using System.Collections.Generic;

namespace POS.WebAPI.Business
{
    public interface INotificationService
    {
        IEnumerable<Notification> GetNotificationByUse(UserAccount user);
    }
}
