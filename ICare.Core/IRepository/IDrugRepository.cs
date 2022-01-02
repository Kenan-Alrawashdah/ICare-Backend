using ICare.Core.ApiDTO;
using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface IDrugRepository
    {
        bool AddToQuantity(int drugId, int quantity);
        bool Create(Drug drug);
        bool Delete(int drugId);
        bool EditDrug(Drug drug);
        Task<IEnumerable<GetAllDrugsApiDTO.Response>> GetAll();
        Task<GetDrugByIdApiDTO.Response> GetById(int drugId);
        Task<IEnumerable<GetCategoryDrugsApiDTO.Response>> GetCategoryDrugs(int drugId);
        Task<IEnumerable<GetAllDrugsApiDTO.Response>> GetRandomdrugs();
    }
}
