using ICare.Core.Data;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    class NotificationTypesServices : INotificationTypesServices
    {
        private readonly INotificationTypesServices _NotificationTypesServices;

        public NotificationTypesServices(INotificationTypesServices NotificationTypesServices)
        {
            this._NotificationTypesServices = NotificationTypesServices;
        }
        public bool Create(NotificationTypes NotificationTypes)
        {
            return _NotificationTypesServices.Create(NotificationTypes);
        }

        public bool Delete(int id)
        {
            return _NotificationTypesServices.Delete(id);
        }

        public IEnumerable<NotificationTypes> GetAll()
        {
            return _NotificationTypesServices.GetAll();
        }

        public NotificationTypes GetById(int id)
        {
            return _NotificationTypesServices.GetById(id);
        }

        public bool Update(NotificationTypes NotificationTypes)
        {
            return _NotificationTypesServices.Update(NotificationTypes);
        }
    }
}
