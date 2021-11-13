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
        Patient GetPatientByUserId(int id);
    }
}
