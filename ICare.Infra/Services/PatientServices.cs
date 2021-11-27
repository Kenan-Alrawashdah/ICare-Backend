using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly IPatientRepository _patientRepository;

        public PatientServices(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }
        public async Task<bool> AddPatientDrugs(PatientDrugs t, List<DrugDoseTime> drugDoseTime)
        {
             return await _patientRepository.AddPatientDrugs(t, drugDoseTime);

        }

        public Patient GetPatientByUserId(int id)
        {
            return _patientRepository.GetPatientByUserId(id);
        }


        public async Task<IEnumerable<MyDrugsApiDto.Drug>> GetMyDrugs(int patientId)
        {
            return await _patientRepository.GetMyDrugs(patientId);
        }
        public async Task<EditDrugApiDTO.Response> GetDrug(int id)
        {
            return await _patientRepository.GetDrug(id);
        }
        public async Task<bool> EditPatientDrugs(PatientDrugs patientDrug, List<DrugDoseTime> drugDoseTime)
        {
            return await _patientRepository.EditPatientDrugs(patientDrug, drugDoseTime);
            }

        public Task<bool> InsertPDFData(InsertPDFDataHealthReportDTO.Request request)
        {
            return _patientRepository.InsertPDFData(request);

        }


        //public bool Create(Patient patient)
        //{
        //    return _patientRepository.Create(patient);
        //}

        //public bool Delete(int id)
        //{
        //    return _patientRepository.Delete(id);
        //}

        //public IEnumerable<Patient> GetAll()
        //{
        //    return _patientRepository.GetAll();
        //}

        //public Patient GetById(int id)
        //{
        //    return _patientRepository.GetById(id);
        //}

        //public bool Update(Patient patient)
        //{
        //    return _patientRepository.Update(patient);
        //}
    }
}
