using ICare.Core.Data;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class HealthReportServices : IHealthReportServices
    {
        private readonly IHealthReportServices _HealthReportServices;

        public HealthReportServices(IHealthReportServices HealthReportServices)
        {
            this._HealthReportServices = HealthReportServices;
        }
        public bool Create(HealthReport healthReport)
        {
            return _HealthReportServices.Create(healthReport);
        }

        public bool Delete(int id)
        {
            return _HealthReportServices.Delete(id);
        }

        public IEnumerable<HealthReport> GetAll()
        {
            return _HealthReportServices.GetAll();
        }

        public HealthReport GetById(int id)
        {
            return _HealthReportServices.GetById(id);
        }

        public bool Update(HealthReport healthReport)
        {
            return _HealthReportServices.Update(healthReport);
        }
    }
}
