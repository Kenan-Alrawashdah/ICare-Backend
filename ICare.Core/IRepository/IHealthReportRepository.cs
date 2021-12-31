using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface IHealthReportRepository : ICRUDRepository<HealthReport>
    {
        Task<IEnumerable<GetHelethReportsApiDTO.Reponse>> GetAllHealthReportByMonth(int patienId, int month, int year);
    }
}
