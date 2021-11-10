using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class DrugDoseTimeServices : ICRUDServices<DrugDoseTime>
    {
        private readonly ICRUDRepository<DrugDoseTime> ICRUDRepository;
        public DrugDoseTimeServices(ICRUDRepository<DrugDoseTime> ICRUDRepository)
        {
            this.ICRUDRepository = ICRUDRepository;
        }
        public bool Create(DrugDoseTime t)
        {
            return ICRUDRepository.Create(t);
        }
        public bool Delete(int id)
        {
            return ICRUDRepository.Delete(id);
        }
        public IEnumerable<DrugDoseTime> GetAll()
        {
            return ICRUDRepository.GetAll();
        }
        public DrugDoseTime GetById(int id)
        {
            return ICRUDRepository.GetById(id);

        }
        public bool Update(DrugDoseTime t)
        {
            return ICRUDRepository.Update(t);

        }
    }
}
