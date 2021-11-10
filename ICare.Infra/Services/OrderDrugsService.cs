using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class OrderDrugsService : IOrderDrugsService
    {
        private readonly IOrderDrugsRepository _orderDrugsRepository;

        public OrderDrugsService(IOrderDrugsRepository orderDrugsRepository)
        {
            _orderDrugsRepository = orderDrugsRepository;
        }
        public bool Create(OrderDrugs orderDrugs)
        {
            return _orderDrugsRepository.Create(orderDrugs);
        }

        public bool Delete(int orderDrugsId)
        {
            return _orderDrugsRepository.Delete(orderDrugsId);
        }

        public IEnumerable<OrderDrugs> GetAll()
        {
            return _orderDrugsRepository.GetAll();
        }

        public OrderDrugs GetById(int orderDrugsId)
        {
            return _orderDrugsRepository.GetById(orderDrugsId);
        }

        public bool Update(OrderDrugs orderDrugs)
        {
            return _orderDrugsRepository.Update(orderDrugs);
        }
    }
}
