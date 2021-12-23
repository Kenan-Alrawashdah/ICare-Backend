using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<GetAllDrugsApiDTO.Response>> GetRandomdrugs()
        {
            return await _drugRepository.GetRandomdrugs();

        }


        public async Task<GetDrugByIdApiDTO.Response> GetById(int drugId)
        {
            return await _drugRepository.GetById(drugId);

        }

        public async Task<IEnumerable<GetCategoryDrugsApiDTO.Response>> GetCategoryDrugs(int drugId)
        {
            return await _drugRepository.GetCategoryDrugs(drugId);

        }
        public async Task<IEnumerable<GetAllDrugsApiDTO.Response>> GetAll()
        {
            return await _drugRepository.GetAll();
        }
        public bool AddToQuantity(int drugId, int quantity)
        {
            return  _drugRepository.AddToQuantity(drugId, quantity);

        }

        public bool EditDrug(Drug drug)
        {
            return _drugRepository.EditDrug(drug);

        }



    }
}
