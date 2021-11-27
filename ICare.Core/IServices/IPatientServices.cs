using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface IPatientServices
    {
       Task<bool> AddPatientDrugs(PatientDrugs t, List<DrugDoseTime> drugDoseTime);
        Task<bool> EditPatientDrugs(PatientDrugs patientDrug, List<DrugDoseTime> drugDoseTime);
        Task<EditDrugApiDTO.Response> GetDrug(int id);
        Task<IEnumerable<MyDrugsApiDto.Drug>> GetMyDrugs(int patientId);
        Patient GetPatientByUserId(int id);
        Task<bool> InsertPDFData(InsertPDFDataHealthReportDTO.Request request);




    }
}
