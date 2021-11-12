using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class HealthReportTypesServices : IHealthReportTypesServices
    {
        private readonly IHealthReportTypesRepository _HealthReportTypesRepository;

        public HealthReportTypesServices(IHealthReportTypesRepository HealthReportTypesRepository)
        {
            this._HealthReportTypesRepository = HealthReportTypesRepository;
        }
        public bool Create(HealthReportTypes HealthReportTypes)
        {
            return _HealthReportTypesRepository.Create(HealthReportTypes);
        }

        public bool Delete(int id)
        {
            return _HealthReportTypesRepository.Delete(id);
        }

        public IEnumerable<HealthReportTypes> GetAll()
        {
            return _HealthReportTypesRepository.GetAll();
        }

        public HealthReportTypes GetById(int id)
        {
            return _HealthReportTypesRepository.GetById(id);
        }

        public bool Update(HealthReportTypes HealthReportTypes)
        {
            return _HealthReportTypesRepository.Update(HealthReportTypes);
        }
    }
}
