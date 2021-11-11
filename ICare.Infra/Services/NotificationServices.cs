using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
namespace ICare.Infra.Services
{
    public class NotificationServices : INotificationServices
    {
        private readonly INotificationRepository _NotificationRepository;

        public NotificationServices(INotificationRepository NotificationRepository)
        {
            this._NotificationRepository = NotificationRepository;
        }
        public bool Create(Notification Notification)
        {
            return _NotificationRepository.Create(Notification);
        }

        public bool Delete(int id)
        {
            return _NotificationRepository.Delete(id);
        }

        public IEnumerable<Notification> GetAll()
        {
            return _NotificationRepository.GetAll();
        }

        public Notification GetById(int id)
        {
            return _NotificationRepository.GetById(id);
        }

        public bool Update(Notification Notification)
        {
            return _NotificationRepository.Update(Notification);
        }
    }
}
