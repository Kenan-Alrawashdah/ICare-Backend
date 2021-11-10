using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface INotificationTypesServices
    {
        bool Create(NotificationTypes notificationTypes);

        bool Update(NotificationTypes notificationTypes);

        bool Delete(int id);

        NotificationTypes GetById(int id);

        IEnumerable<NotificationTypes> GetAll();
    }
}
