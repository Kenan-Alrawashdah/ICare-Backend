using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Infra.Services
{
    public class DrugCategoryService : IDrugCategoryService
    {
        private readonly IDrugCategoryRepository _drugCategoryRepository;

        public DrugCategoryService(IDrugCategoryRepository drugCategoryRepository)
        {
            _drugCategoryRepository = drugCategoryRepository;
        }
        public bool Create(DrugCategory drugCategory)
        {
           return _drugCategoryRepository.Create(drugCategory);
        }

        public bool Delete(int drugCategoryId)
        {
            return _drugCategoryRepository.Delete(drugCategoryId);
        }

        public IEnumerable<DrugCategory> GetAll()
        {
            return _drugCategoryRepository.GetAll();
        }

        public DrugCategory GetById(int drugCategoryId)
        {
            return _drugCategoryRepository.GetById(drugCategoryId);
        }

        public bool Update(DrugCategory drugCategory)
        {
            return _drugCategoryRepository.Update(drugCategory);
        }
    }
}
