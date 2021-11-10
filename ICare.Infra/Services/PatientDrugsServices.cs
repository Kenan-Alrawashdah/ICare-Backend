using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class PatientDrugsServices : IPatientDrugsServices
    {
        private readonly IPatientDrugsServices _patientDrugsServices;
        public PatientDrugsServices(IPatientDrugsServices patientDrugsServices)
        {
            this._patientDrugsServices = patientDrugsServices;
        }
        public bool Create(PatientDrugs t)
        {
            return _patientDrugsServices.Create(t);
        }

        public bool Delete(int id)
        {
            return _patientDrugsServices.Delete(id);
        }

        public IEnumerable<PatientDrugs> GetAll()
        {
            return _patientDrugsServices.GetAll();
        }

        public PatientDrugs GetById(int id)
        {
            return _patientDrugsServices.GetById(id);
        }

        public bool Update(PatientDrugs t)
        {
            return _patientDrugsServices.Update(t);
        }

    }
}
