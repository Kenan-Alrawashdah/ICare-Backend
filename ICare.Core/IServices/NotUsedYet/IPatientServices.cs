using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Core.IServices
{
    public interface IPatientServices
    {
        bool Create(Patient patient);

        bool Update(Patient patient);

        bool Delete(int id);

        Patient GetById(int id);

        IEnumerable<Patient> GetAll();
    }
}
