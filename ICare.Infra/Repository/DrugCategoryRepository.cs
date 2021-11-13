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
    public class DrugCategoryRepository : IDrugCategoryRepository
    {
        private readonly IDbContext _dbContext;

        public DrugCategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(DrugCategory drugCategory)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@CreatedOn", drugCategory.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@Name", drugCategory.Name, dbType: DbType.String, direction: ParameterDirection.Input);
                param.Add("@PicturePath", drugCategory.PicturePath, dbType: DbType.String, direction: ParameterDirection.Input);


                _dbContext.Connection.Execute("DrugCategoryInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public bool Delete(int drugCategoryId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", drugCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("DrugCategoryDelete", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public IEnumerable<DrugCategory> GetAll()
        {
            var drugCategorys = _dbContext.Connection.Query<DrugCategory>("DrugCategoryGetAll", commandType: CommandType.StoredProcedure);

            return drugCategorys;
        }

        public DrugCategory GetById(int drugCategoryId)
        {
            var param = new DynamicParameters();
            param.Add("@Id", drugCategoryId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var drugCategory = _dbContext.Connection.QueryFirstOrDefault<DrugCategory>("DrugCategorySelect", param, commandType: CommandType.StoredProcedure);

            return drugCategory;
        }

        public bool Update(DrugCategory drugCategory)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@Id", drugCategory.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@Name", drugCategory.Name, dbType: DbType.String, direction: ParameterDirection.Input);
                if(drugCategory.PicturePath != null)
                {
                param.Add("@PicturePath", drugCategory.PicturePath, dbType: DbType.String, direction: ParameterDirection.Input);
                }
                else
                {
                    param.Add("@PicturePath", "0", dbType: DbType.String, direction: ParameterDirection.Input);
                }


                _dbContext.Connection.Execute("DrugCategoryUpdate", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
