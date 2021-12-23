using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface ISubscriptionServices
    {
        Task<IEnumerable<SubscribeType>> GetAll();

        //Task<bool> AddPatientSubscription(AddPatientSubscriptionDTO.Request request);
        //Task<bool> DeletePatientSubscription(int id);
        //Task<Subscription> GetByPatientId(int id);
        //Task<bool> UpdatePatientSubscription(UpdatePatientSubscriptionDTO.Request request);
        //Task<IEnumerable<GetAllPatientSubscriptionDTO>> GetAllPatientSubscription();
        //Task<Payment> SubscriptionPayment(SubscriptionPaymentDTO.Request request);
        bool SubscriptionInsert(int patientId, int subscriptionId);
    }
}
