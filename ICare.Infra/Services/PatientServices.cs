using ICare.Core.Data;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly IPatientServices _patientServices;

        public PatientServices(IPatientServices patientServices)
        {
            this._patientServices = patientServices;
        }
        public bool Create(Patient patient)
        {
            return _patientServices.Create(patient);
        }

        public bool Delete(int id)
        {
            return _patientServices.Delete(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientServices.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientServices.GetById(id);
        }

        public bool Update(Patient patient)
        {
            return _patientServices.Update(patient);
        }
    }
}
