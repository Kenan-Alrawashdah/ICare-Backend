using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class SubscriptionServices : ISubscriptionServices
    {
        private readonly ISubscriptionRepository _SubscriptionRepository;

        public SubscriptionServices(ISubscriptionRepository SubscriptionRepository)
        {
            this._SubscriptionRepository = SubscriptionRepository;
        }

        public bool SubscriptionInsert(int patientId, int subscriptionId)
        {
            return  _SubscriptionRepository.SubscriptionInsert(patientId, subscriptionId);
        }

        public async Task<IEnumerable<SubscribeType>> GetAll()
        {
            return await _SubscriptionRepository.GetAll();

        }
    }
}
