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
        private readonly IPatientDrugsRepository _patientDrugsRepository;
        public PatientDrugsServices(IPatientDrugsRepository patientDrugsServices)
        {
            this._patientDrugsRepository = patientDrugsServices;
        }
        public bool Create(PatientDrugs t)
        {
            return _patientDrugsRepository.Create(t);
        }

        public bool Delete(int id)
        {
            return _patientDrugsRepository.Delete(id);
        }

        public IEnumerable<PatientDrugs> GetAll()
        {
            return _patientDrugsRepository.GetAll();
        }

        public PatientDrugs GetById(int id)
        {
            return _patientDrugsRepository.GetById(id);
        }

        public bool Update(PatientDrugs t)
        {
            return _patientDrugsRepository.Update(t);
        }

    }
}
