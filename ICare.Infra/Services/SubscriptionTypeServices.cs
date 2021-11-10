using ICare.Core.Data;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    class SubscriptionTypeServices : ISubscriptionTypeServices
    {
        private readonly ISubscriptionTypeServices _subscriptionTypeServices;

        public SubscriptionTypeServices(ISubscriptionTypeServices subscriptionTypeServices)
        {
            this._subscriptionTypeServices = subscriptionTypeServices;
        }
        public bool Create(SubscribeType subscribeType)
        {
            return _subscriptionTypeServices.Create(subscribeType);
        }

        public bool Delete(int id)
        {
            return _subscriptionTypeServices.Delete(id);
        }

        public IEnumerable<SubscribeType> GetAll()
        {
            return _subscriptionTypeServices.GetAll();
        }

        public SubscribeType GetById(int id)
        {
            return _subscriptionTypeServices.GetById(id);
        }

        public bool Update(SubscribeType subscribeType)
        {
            return _subscriptionTypeServices.Update(subscribeType);
        }
    }
}
