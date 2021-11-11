using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class DrugDoseTimeServices : IDrugDoseTimeServices
    {
        private readonly IDrugDoseTimeRepository _drugDoseTimeRepository;
        public DrugDoseTimeServices(IDrugDoseTimeRepository drugDoseTimeRepository)
        {
            this._drugDoseTimeRepository = drugDoseTimeRepository;
        }
        public bool Create(DrugDoseTime t)
        {
            return _drugDoseTimeRepository.Create(t);
        }
        public bool Delete(int id)
        {
            return _drugDoseTimeRepository.Delete(id);
        }
        public IEnumerable<DrugDoseTime> GetAll()
        {
            return _drugDoseTimeRepository.GetAll();
        }
        public DrugDoseTime GetById(int id)
        {
            return _drugDoseTimeRepository.GetById(id);

        }
        public bool Update(DrugDoseTime t)
        {
            return _drugDoseTimeRepository.Update(t);

        }
    }
}
