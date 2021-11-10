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
        private readonly IDrugDoseTimeServices _drugDoseTimeServices;
        public DrugDoseTimeServices(IDrugDoseTimeServices drugDoseTimeServices)
        {
            this._drugDoseTimeServices = drugDoseTimeServices;
        }
        public bool Create(DrugDoseTime t)
        {
            return _drugDoseTimeServices.Create(t);
        }
        public bool Delete(int id)
        {
            return _drugDoseTimeServices.Delete(id);
        }
        public IEnumerable<DrugDoseTime> GetAll()
        {
            return _drugDoseTimeServices.GetAll();
        }
        public DrugDoseTime GetById(int id)
        {
            return _drugDoseTimeServices.GetById(id);

        }
        public bool Update(DrugDoseTime t)
        {
            return _drugDoseTimeServices.Update(t);

        }
    }
}
