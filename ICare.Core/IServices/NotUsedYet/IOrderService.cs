using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface IOrderService
    {
        Task<bool> Create(Order order, List<int> orderDrugs);
        Task<IEnumerable<GetAllOpenOredersApiDTO.Response>> GetAllOpenOrders();
        Task<IEnumerable<OrderDrugsApiDTO.Response>> GetOrderDrugs(int orderId);
        Task<IEnumerable<PaitentOrderApiDTO.Response>> GetPatientOrders(int patientID);
        Task<IEnumerable<PlacedOrdersApiDTO.Response>> GetPlacedOrders();
        bool SetOrderAsCanceled(int orderId);
        bool SetOrderAsPlaced(int orderId);
    }
}
