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
        bool Create(Drug drug);
        Task<GetDrugByIdApiDTO.Response> GetById(int drugId);
        Task<IEnumerable<GetCategoryDrugsApiDTO.Response>> GetCategoryDrugs(int drugId);
    }
}
