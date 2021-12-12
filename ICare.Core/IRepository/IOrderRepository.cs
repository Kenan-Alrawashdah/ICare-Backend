using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface IOrderRepository
    {
        Task<bool> Create(Order order, List<int> cartIds);
        Task<IEnumerable<PaitentOrderApiDTO.Response>> GetPatientOrders(int patientID);
    }
}
