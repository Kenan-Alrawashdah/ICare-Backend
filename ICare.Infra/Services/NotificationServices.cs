using ICare.Core.Data;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
namespace ICare.Infra.Services
{
    public class NotificationServices : INotificationServices
    {
        private readonly INotificationServices _NotificationServices;

        public NotificationServices(INotificationServices NotificationServices)
        {
            this._NotificationServices = NotificationServices;
        }
        public bool Create(Notification Notification)
        {
            return _NotificationServices.Create(Notification);
        }

        public bool Delete(int id)
        {
            return _NotificationServices.Delete(id);
        }

        public IEnumerable<Notification> GetAll()
        {
            return _NotificationServices.GetAll();
        }

        public Notification GetById(int id)
        {
            return _NotificationServices.GetById(id);
        }

        public bool Update(Notification Notification)
        {
            return _NotificationServices.Update(Notification);
        }
    }
}
