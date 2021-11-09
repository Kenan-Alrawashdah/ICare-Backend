using ICare.Core.Data;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class HealthReportTypesServices : IHealthReportTypesServices
    {
        private readonly IHealthReportTypesServices _HealthReportTypesServices;

        public HealthReportTypesServices(IHealthReportTypesServices HealthReportTypesServices)
        {
            this._HealthReportTypesServices = HealthReportTypesServices;
        }
        public bool Create(HealthReportTypes HealthReportTypes)
        {
            return _HealthReportTypesServices.Create(HealthReportTypes);
        }

        public bool Delete(int id)
        {
            return _HealthReportTypesServices.Delete(id);
        }

        public IEnumerable<HealthReportTypes> GetAll()
        {
            return _HealthReportTypesServices.GetAll();
        }

        public HealthReportTypes GetById(int id)
        {
            return _HealthReportTypesServices.GetById(id);
        }

        public bool Update(HealthReportTypes HealthReportTypes)
        {
            return _HealthReportTypesServices.Update(HealthReportTypes);
        }
    }
}
