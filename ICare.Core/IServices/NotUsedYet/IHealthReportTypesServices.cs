using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IHealthReportTypesServices
    {
        bool Create(HealthReportTypes healthReportTypes);

        bool Update(HealthReportTypes healthReportTypes);

        bool Delete(int id);

        HealthReportTypes GetById(int id);

        IEnumerable<HealthReportTypes> GetAll();
    }
}
