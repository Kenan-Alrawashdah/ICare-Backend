using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }


        public bool Create(Delivery delivery)
        {
            return _deliveryRepository.Create(delivery);
        }

        public bool Delete(int id)
        {
            return _deliveryRepository.Delete(id);
        }

        public IEnumerable<Delivery> GetAll()
        {
            return _deliveryRepository.GetAll();
        }


        public Delivery GetById(int id)
        {
            return _deliveryRepository.GetById(id);
        }

        public Task<getNumberOfOrdersForDeliveryDTO.Response> getNumberOfOrdersForDelivery(getNumberOfOrdersForDeliveryDTO.Request request)
        {
            return _deliveryRepository.getNumberOfOrdersForDelivery(request);
        }

       

        public bool OrderDeliverd(int id)
        {
            return _deliveryRepository.OrderDeliverd(id);
        }



        public bool Update(Delivery delivery)
        {
            return _deliveryRepository.Update(delivery);
        }

        public bool TakeOrder(int orderId, int deliveryId)
        {
            return _deliveryRepository.TakeOrder(orderId, deliveryId);

        }

        public Delivery GetDeliveryByUserId(int userId)
        {
            return _deliveryRepository.GetDeliveryByUserId(userId);
        }
        public async Task<IEnumerable<getAllOrdersForDeliveryDTO.Response>> getAllOrdersForDelivery(int deliveryId)
        {
            return await _deliveryRepository.getAllOrdersForDelivery(deliveryId);
        }

    }
}
