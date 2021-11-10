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
    class HealthReportTypesRepository : IHealthReportTypesRepository
    {
        private readonly IDbContext _dbContext;

        public HealthReportTypesRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(HealthReportTypes t)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn"  , t.CreatedOn   , DbType.DateTime   , ParameterDirection.Input);
            p.Add("@Type"       , t.Type        , DbType.String     , ParameterDirection.Input);



            try
            {
                var result = _dbContext.Connection.Execute("HealthReportTypesInsert", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("HealthReportTypesDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<HealthReportTypes> GetAll()
        {
            var result = _dbContext.Connection.Query<HealthReportTypes>("GetAllHealthReportTypes", commandType: CommandType.StoredProcedure);
            return result;
        }

        public HealthReportTypes GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<HealthReportTypes>("HealthReportTypesSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(HealthReportTypes t)
        {
            var p = new DynamicParameters();
            p.Add("@Id"         , t.Id          , dbType: DbType.Int32  , ParameterDirection.Input);
            p.Add("@CreatedOn"  , t.CreatedOn   , DbType.DateTime       , ParameterDirection.Input);
            p.Add("@Type"       , t.Type        , DbType.String         , ParameterDirection.Input);


            try
            {
                var result = _dbContext.Connection.Execute("HealthReportTypesUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
    }
}
