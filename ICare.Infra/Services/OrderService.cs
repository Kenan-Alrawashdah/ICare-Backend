using ICare.Core.ApiDTO;
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

        public IEnumerable<GetPaymentOrdersDTO.Response> GetPaymentOrders()
        {
            return _orderRepository.GetPaymentOrders();
        }

        public IEnumerable<GetSalesStatsLast5YearDTO> GetSalesStatsLast5Year()
        {
            return _orderRepository.GetSalesStatsLast5Year();
        }

        public IEnumerable<GetPaymentOrdersDTO.Response> SearchInByDatePaymentOrders(GetPaymentOrdersDTO.Resqust resqust)
        {
            return _orderRepository.SearchInByDatePaymentOrders(resqust);
        }

        public bool Update(Order order)
        {
            return _orderRepository.Update(order);
        }

    }
}
