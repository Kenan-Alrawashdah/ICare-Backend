using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class NotificationTypesServices : INotificationTypesServices
    {
        private readonly INotificationTypesRepository _NotificationTypesRepository;

        public NotificationTypesServices(INotificationTypesRepository NotificationTypesRepository)
        {
            this._NotificationTypesRepository = NotificationTypesRepository;
        }
        public bool Create(NotificationTypes NotificationTypes)
        {
            return _NotificationTypesRepository.Create(NotificationTypes);
        }

        public bool Delete(int id)
        {
            return _NotificationTypesRepository.Delete(id);
        }

        public IEnumerable<NotificationTypes> GetAll()
        {
            return _NotificationTypesRepository.GetAll();
        }

        public NotificationTypes GetById(int id)
        {
            return _NotificationTypesRepository.GetById(id);
        }

        public bool Update(NotificationTypes NotificationTypes)
        {
            return _NotificationTypesRepository.Update(NotificationTypes);
        }
    }
}
