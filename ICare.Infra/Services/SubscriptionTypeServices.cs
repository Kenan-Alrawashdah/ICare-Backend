using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class SubscriptionTypeServices : ISubscriptionTypeServices
    {
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;

        public SubscriptionTypeServices(ISubscriptionTypeRepository subscriptionTypeRepositorys)
        {
            this._subscriptionTypeRepository = subscriptionTypeRepositorys;
        }
        public bool Create(SubscribeType subscribeType)
        {
            return _subscriptionTypeRepository.Create(subscribeType);
        }

        public bool Delete(int id)
        {
            return _subscriptionTypeRepository.Delete(id);
        }

        public IEnumerable<SubscribeType> GetAll()
        {
            return _subscriptionTypeRepository.GetAll();
        }

        public SubscribeType GetById(int id)
        {
            return _subscriptionTypeRepository.GetById(id);
        }

        public bool Update(SubscribeType subscribeType)
        {
            return _subscriptionTypeRepository.Update(subscribeType);
        }
    }
}
