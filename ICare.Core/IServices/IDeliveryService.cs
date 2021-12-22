using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface IDeliveryService : ICRUDRepository<Delivery>
    {

        Task<IEnumerable<getAllOrdersForDeliveryDTO.Response>> getAllOrdersForDelivery(int deliveryId);
        Delivery GetDeliveryByUserId(int userId);
        Task<getNumberOfOrdersForDeliveryDTO.Response> getNumberOfOrdersForDelivery(getNumberOfOrdersForDeliveryDTO.Request request);
        bool OrderDeliverd(int id);
        bool RegistrationDelivery(CreateDeliveryApiDTO.Request userModle);
        bool TakeOrder(int orderId, int deliveryId);
    }
}
