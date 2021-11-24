using Dapper;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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


                _dbContext.Connection.Execute("DrugInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public bool Delete(int drugId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", drugId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("DrugDelete", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public IEnumerable<Drug> GetAll()
        {
            var drugs = _dbContext.Connection.Query<Drug>("DrugGetAll", commandType: CommandType.StoredProcedure);

            return drugs;
        }

        public Drug GetById(int drugId)
        {
            var param = new DynamicParameters();
            param.Add("@Id", drugId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var drug = _dbContext.Connection.QueryFirstOrDefault<Drug>("DrugSelect", param, commandType: CommandType.StoredProcedure);

            return drug;
        }

        public bool Update(Drug drug)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@Id", drug.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@CreatedOn", drug.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@DrugCategoryId", drug.DrugCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@Price", drug.Price, dbType: DbType.Double, direction: ParameterDirection.Input);
                param.Add("@PicturePath", drug.PicturePath, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("@Name", drug.Name, dbType: DbType.String, direction: ParameterDirection.Input);


                _dbContext.Connection.Execute("DrugUpdate", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }
    }
}
