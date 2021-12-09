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
        bool Create(Drug drug);
        Task<GetDrugByIdApiDTO.Response> GetById(int drugId);
        Task<IEnumerable<GetCategoryDrugsApiDTO.Response>> GetCategoryDrugs(int drugId);
    }
}
