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
        Task<IEnumerable<getAllOrdersForDeliveryDTO.Response>> getAllOrdersAvailableForDelivery();

        Task<IEnumerable<getAllOrdersForDeliveryDTO.Response>> getAllOrdersForDelivery(getAllOrdersForDeliveryDTO.Request request);
        Task<getNumberOfOrdersForDeliveryDTO.Response> getNumberOfOrdersForDelivery(getNumberOfOrdersForDeliveryDTO.Request request);
        Task<getReservationAvailableCountDTO> ReservationAvailableCount();

        bool TakeOrder(int id);
        bool OrderDeliverd(int id);
        bool ReservationAvailable(int id);

    }
}
