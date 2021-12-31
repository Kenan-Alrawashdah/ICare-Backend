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
   public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Create(Order order, List<int> orderDrugs)
        {
          return await _orderRepository.Create(order, orderDrugs);
        }

        public async Task<IEnumerable<PaitentOrderApiDTO.Response>> GetPatientOrders(int patientID)
        {
            return await _orderRepository.GetPatientOrders(patientID);

        }

        public async Task<IEnumerable<GetAllOpenOredersApiDTO.Response>> GetAllOpenOrders()
        {
            return await _orderRepository.GetAllOpenOrders();

        }

        public async Task<IEnumerable<OrderDrugsApiDTO.Response>> GetOrderDrugs(int orderId)
        {
            return await _orderRepository.GetOrderDrugs(orderId);

        }
        public bool SetOrderAsPlaced(int orderId)
        {
            return  _orderRepository.SetOrderAsPlaced(orderId);

        }
        public bool SetOrderAsCanceled(int orderId)
        {
            return _orderRepository.SetOrderAsCanceled(orderId);
        }

        public async Task<IEnumerable<PlacedOrdersApiDTO.Response>> GetPlacedOrders()
        {
            return await _orderRepository.GetPlacedOrders();
        }

        public async Task<OrderDetailsApiDTO.Response> GetOrderDetails(int orderId)
        {
            return await _orderRepository.GetOrderDetails(orderId);

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

        public bool SetOrderAsDelivered(int orderId)
        {
            return _orderRepository.SetOrderAsDelivered(orderId);
        }
    }
}
