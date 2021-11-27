using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface INotificationServices
    {
        bool Create(Notification notification);

        bool Update(Notification notification);

        bool Delete(int id);

        Notification GetById(int id);

        IEnumerable<Notification> GetAll();
    }
}
