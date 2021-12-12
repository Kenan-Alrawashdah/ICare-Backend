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

    }
}
