using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IServices
{
    public interface IDrugService
    {
        bool AddToQuantity(int drugId, int quantity);
        bool Create(Drug drug);
        bool EditDrug(Drug drug);
        Task<IEnumerable<GetAllDrugsApiDTO.Response>> GetAll();
        Task<GetDrugByIdApiDTO.Response> GetById(int drugId);
        Task<IEnumerable<GetCategoryDrugsApiDTO.Response>> GetCategoryDrugs(int drugId);
    }
}
