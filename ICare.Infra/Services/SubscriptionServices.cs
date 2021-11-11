using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class SubscriptionServices : ISubscriptionServices
    {
        private readonly ISubscriptionRepository _SubscriptionRepository;

        public SubscriptionServices(ISubscriptionRepository SubscriptionRepository)
        {
            this._SubscriptionRepository = SubscriptionRepository;
        }
        public bool Create(Subscription Subscription)
        {
            return _SubscriptionRepository.Create(Subscription);
        }

        public bool Delete(int id)
        {
            return _SubscriptionRepository.Delete(id);
        }

        public IEnumerable<Subscription> GetAll()
        {
            return _SubscriptionRepository.GetAll();
        }

        public Subscription GetById(int id)
        {
            return _SubscriptionRepository.GetById(id);
        }

        public bool Update(Subscription Subscription)
        {
            return _SubscriptionRepository.Update(Subscription);
        }
    }
}
