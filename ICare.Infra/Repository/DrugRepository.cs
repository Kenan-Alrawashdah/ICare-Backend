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
    public class DrugRepository : IDrugRepository
    {
        private readonly IDbContext _dbContext;

        public DrugRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Drug drug)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@DrugCategoryId", drug.DrugCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@Price", drug.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
                param.Add("@PicturePath", drug.PicturePath, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("@Name", drug.Name, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("@Brand", drug.Brand, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("@AvailableQuantity", drug.AvailableQuantity, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@Description", drug.Description, dbType: DbType.String, direction: ParameterDirection.Input);


                _dbContext.Connection.Execute("DrugInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public async Task<GetDrugByIdApiDTO.Response> GetById(int drugId)
        {
            var param = new DynamicParameters();
            param.Add("@Id", drugId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var drug = await _dbContext.Connection.QueryFirstOrDefaultAsync<GetDrugByIdApiDTO.Response>("DrugSelect", param, commandType: CommandType.StoredProcedure);

            return drug;
        }

        public async Task<IEnumerable<GetCategoryDrugsApiDTO.Response>> GetCategoryDrugs(int drugId)
        {
            var param = new DynamicParameters();
            param.Add("@Id", drugId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var drug = await _dbContext.Connection.QueryAsync<GetCategoryDrugsApiDTO.Response>("GetCategoryDrugs", param, commandType: CommandType.StoredProcedure);

            return drug;
        }


        public async Task<IEnumerable<GetAllDrugsApiDTO.Response>> GetAll()
        {
            var drugs =await _dbContext.Connection.QueryAsync<GetAllDrugsApiDTO.Response>("DrugGetAll", commandType: CommandType.StoredProcedure);

            return drugs;
        }

        public bool AddToQuantity(int drugId , int quantity)
        {
            var p = new DynamicParameters();
            p.Add("@Id", drugId, DbType.Int32, ParameterDirection.Input); 
            p.Add("@Quantity", quantity, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("AddToQuantity", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool EditDrug(Drug drug)
        {
            var p = new DynamicParameters();
            p.Add("@Id", drug.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("@DrugCategoryId", drug.DrugCategoryId, DbType.Int32, ParameterDirection.Input);
            p.Add("@Name", drug.Name, DbType.String, ParameterDirection.Input);
            p.Add("@Price", drug.Price, DbType.Double, ParameterDirection.Input);
            p.Add("@PicturePath", drug.PicturePath, DbType.String, ParameterDirection.Input);
            p.Add("@Brand", drug.Brand, DbType.String, ParameterDirection.Input);
            p.Add("@AvailableQuantity", drug.AvailableQuantity, DbType.Int32, ParameterDirection.Input);
            p.Add("@Description", drug.Description, DbType.String, ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("DrugUpdate", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //public IEnumerable<Drug> GetAll()
        //{
        //    var drugs = _dbContext.Connection.Query<Drug>("DrugGetAll", commandType: CommandType.StoredProcedure);

        //    return drugs;
        //}
        //public bool Update(Drug drug)
        //{
        //    try
        //    {
        //        var param = new DynamicParameters();

        //        param.Add("@Id", drug.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@CreatedOn", drug.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        //        param.Add("@DrugCategoryId", drug.DrugCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@Price", drug.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
        //        param.Add("@PicturePath", drug.PicturePath, dbType: DbType.String, direction: ParameterDirection.Input);
        //        param.Add("@Name", drug.Name, dbType: DbType.String, direction: ParameterDirection.Input);


        //        _dbContext.Connection.Execute("DrugUpdate", param, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception erorr)
        //    {
        //        return false;
        //    }
        //}
        //public bool Delete(int drugId)
        //{
        //    try
        //    {
        //        var param = new DynamicParameters();
        //        param.Add("@Id", drugId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        _dbContext.Connection.Execute("DrugDelete", param, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception erorr)
        //    {
        //        return false;
        //    }
        //}
    }
}
