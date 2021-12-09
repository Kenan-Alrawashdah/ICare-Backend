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
        public Task<bool> AddPatientSubscription(AddPatientSubscriptionDTO.Request request)
        {
            return _SubscriptionRepository.AddPatientSubscription(request);
        }

        public Task<bool> DeletePatientSubscription(int id)
        {
            return _SubscriptionRepository.DeletePatientSubscription(id);
        }


        public Task<IEnumerable<GetAllPatientSubscriptionDTO>> GetAllPatientSubscription()
        {
            return _SubscriptionRepository.GetAllPatientSubscription();
        }

        public Task<Subscription> GetByPatientId(int id)
        {
            return _SubscriptionRepository.GetByPatientId(id);
        }

        public Task<Payment> SubscriptionPayment(SubscriptionPaymentDTO.Request request)
        {
            return _SubscriptionRepository.SubscriptionPayment(request);
        }

        public Task<bool> UpdatePatientSubscription(UpdatePatientSubscriptionDTO.Request request)
        {
            return _SubscriptionRepository.UpdatePatientSubscription(request);
        }
    }
}
