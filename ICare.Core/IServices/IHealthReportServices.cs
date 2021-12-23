using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface IHealthReportServices
    {
        bool Create(HealthReport healthReport);

        bool Update(HealthReport healthReport);

        bool Delete(int id);

        HealthReport GetById(int id);

        IEnumerable<HealthReport> GetAll();
        Task<IEnumerable<GetHelethReportsApiDTO.Reponse>> GetAllHelthReportByMonth(int patienId, int month, int year);
    }
}
