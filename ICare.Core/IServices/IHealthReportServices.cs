using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IHealthReportServices
    {
        bool Create(HealthReport healthReport);

        bool Update(HealthReport healthReport);

        bool Delete(int id);

        HealthReport GetById(int id);

        IEnumerable<HealthReport> GetAll();
    }
}
