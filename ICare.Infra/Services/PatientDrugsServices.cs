using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class PatientDrugsServices : ICRUDServices<PatientDrugs>
    {
        private readonly ICRUDRepository<PatientDrugs> ICRUDRepository;
        public PatientDrugsServices(ICRUDRepository<PatientDrugs> ICRUDRepository)
        {
            this.ICRUDRepository = ICRUDRepository;
        }
        public bool Create(PatientDrugs t)
        {
            return ICRUDRepository.Create(t);
        }

        public bool Delete(int id)
        {
            return ICRUDRepository.Delete(id);
        }

        public IEnumerable<PatientDrugs> GetAll()
        {
            return ICRUDRepository.GetAll();
        }

        public PatientDrugs GetById(int id)
        {
            return ICRUDRepository.GetById(id);
        }

        public bool Update(PatientDrugs t)
        {
            return ICRUDRepository.Update(t);
        }

    }
}
