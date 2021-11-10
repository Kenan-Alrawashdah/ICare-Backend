using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

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

        public bool Update(Delivery delivery)
        {
            return _deliveryRepository.Update(delivery);
        }
    }
}
