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

        public Task<IEnumerable<getAllOrdersForDeliveryDTO.Response>> getAllOrdersForDelivery(getAllOrdersForDeliveryDTO.Request request)
        {
            return _deliveryRepository.getAllOrdersForDelivery(request);
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

        public bool TakeOrder(int id)
        {
            return _deliveryRepository.TakeOrder(id);
        }

        public bool Update(Delivery delivery)
        {
            return _deliveryRepository.Update(delivery);
        }

    }
}
