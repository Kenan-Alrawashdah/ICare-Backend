using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
   public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public bool Create(Order order)
        {
            return _orderRepository.Create(order);
        }

        public bool Delete(int orderId)
        {
            return _orderRepository.Delete(orderId);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(int orderId)
        {
            return _orderRepository.GetById(orderId);
        }

        public bool Update(Order order)
        {
            return _orderRepository.Update(order);
        }
    }
}
