using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IOrderService : ICRUDRepository<Order>
    {
        IEnumerable<GetPaymentOrdersDTO.Response> GetPaymentOrders();
        IEnumerable<GetPaymentOrdersDTO.Response> SearchInByDatePaymentOrders(GetPaymentOrdersDTO.Resqust resqust);
        IEnumerable<GetSalesStatsLast5YearDTO> GetSalesStatsLast5Year();


    }
}
