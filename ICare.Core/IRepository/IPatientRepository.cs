using ICare.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface IPatientRepository
    {
        Task<bool> AddPatientDrugs(PatientDrugs t, List<DrugDoseTime> drugDoseTime);
        Patient GetPatientByUserId(int id);
    }
}
