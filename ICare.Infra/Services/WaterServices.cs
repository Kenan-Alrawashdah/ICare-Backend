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
    public class WaterServices : IWaterServices
    {
        private readonly IWaterRepository _waterRepository;

        public WaterServices(IWaterRepository waterRepository)
        {
            this._waterRepository = waterRepository;
        }

        public bool AddWater(AddWaterApiDTO.Request water, int patientId)

        {
            return _waterRepository.AddWater(water, patientId);
        }

        public bool EditWater(EditWaterApiDTO.Request water)
        {
            return _waterRepository.EditWater(water);
        }

        public bool DeleteWater(int id)
        {
            return _waterRepository.DeleteWater(id);
        }
        public async Task<Water> GetWaterByUserId(int userId)
        {
            return await _waterRepository.GetWaterByUserId(userId);
        }
    }
}
