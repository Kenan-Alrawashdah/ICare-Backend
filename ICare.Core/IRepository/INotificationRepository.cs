using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface INotificationRepository : ICRUDRepository<Notification>
    {
        Task<IEnumerable<GetNotifications.Response>> UserNotificationsByDate(DateTime date, int patientId);
    }
}
