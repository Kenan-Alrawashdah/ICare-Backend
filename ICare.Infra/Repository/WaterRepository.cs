using Dapper;
using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Repository
{
    public class WaterRepository : IWaterRepository
    {
        private readonly IDbContext _dbContext;

        public WaterRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool AddWater(AddWaterApiDTO.Request water,int patientId)
        {
            var p = new DynamicParameters();
            p.Add("@PatientId", patientId, DbType.Int32, ParameterDirection.Input); 
            p.Add("@Evry", water.Every, DbType.Int32, ParameterDirection.Input); 
            p.Add("@From", water.From, DbType.Time, ParameterDirection.Input); 
            p.Add("@To", water.To, DbType.Time, ParameterDirection.Input);
            try
            {
                var result = _dbContext.Connection.ExecuteAsync("WaterInsert", p, commandType: CommandType.StoredProcedure);
                return true; 
            }
            catch (Exception e )
            {
                return false;
            }
        }

        public bool EditWater(EditWaterApiDTO.Request water)
        {
            var p = new DynamicParameters();
            p.Add("@Id", water.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("@Every", water.Every, DbType.Int32, ParameterDirection.Input);
            p.Add("@From", water.From, DbType.Time, ParameterDirection.Input);
            p.Add("@To", water.To, DbType.Time, ParameterDirection.Input);
            try
            {
                var result = _dbContext.Connection.Execute("WaterUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteWater(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            try
            {
                var result = _dbContext.Connection.Execute("WaterDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Water> GetWaterByUserId(int userId)
        {
            var p = new DynamicParameters();
            p.Add("@userId", userId ,DbType.Int32, ParameterDirection.Input);
            
           return await _dbContext.Connection.QueryFirstOrDefaultAsync<Water>("GetWaterByUserId", p, commandType: CommandType.StoredProcedure);
           
        }
    }
}
