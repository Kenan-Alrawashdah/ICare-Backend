using ICare.Core.Data;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class SubscriptionServices : ISubscriptionServices
    {
        private readonly ISubscriptionServices _SubscriptionServices;

        public SubscriptionServices(ISubscriptionServices SubscriptionServices)
        {
            this._SubscriptionServices = SubscriptionServices;
        }
        public bool Create(Subscription Subscription)
        {
            return _SubscriptionServices.Create(Subscription);
        }

        public bool Delete(int id)
        {
            return _SubscriptionServices.Delete(id);
        }

        public IEnumerable<Subscription> GetAll()
        {
            return _SubscriptionServices.GetAll();
        }

        public Subscription GetById(int id)
        {
            return _SubscriptionServices.GetById(id);
        }

        public bool Update(Subscription Subscription)
        {
            return _SubscriptionServices.Update(Subscription);
        }
    }
}
