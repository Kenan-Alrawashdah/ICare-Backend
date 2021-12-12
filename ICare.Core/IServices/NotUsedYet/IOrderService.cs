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
        Task<IEnumerable<PaitentOrderApiDTO.Response>> GetPatientOrders(int patientID);
    }
}
