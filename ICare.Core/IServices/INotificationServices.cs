using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface INotificationServices
    {
        bool Create(Notification notification);

        bool Update(Notification notification);

        bool Delete(int id);

        Notification GetById(int id);

        IEnumerable<Notification> GetAll();
        Task<IEnumerable<GetNotifications.Response>> UserNotificationsByDate(DateTime date, int patientId);
    }
}
