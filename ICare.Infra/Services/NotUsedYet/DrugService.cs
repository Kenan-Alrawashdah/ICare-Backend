using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;

        public DrugService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public bool Create(Drug drug)
        {
            return _drugRepository.Create(drug);
        }

        public bool Delete(int drugId)
        {
            return _drugRepository.Delete(drugId);
        }

        public IEnumerable<Drug> GetAll()
        {
            return _drugRepository.GetAll();
        }

        public Drug GetById(int drugId)
        {
            return _drugRepository.GetById(drugId);
        }

        public bool Update(Drug drug)
        {
            return _drugRepository.Update(drug);
        }
    }
}
