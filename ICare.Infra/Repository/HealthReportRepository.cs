using ICare.Core.IRepository;
using Dapper;
using ICare.Core.Data;
using ICare.Core.ICommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ICare.Core.ApiDTO;

namespace ICare.Infra.Repository
{
    public class HealthReportRepository : IHealthReportRepository
    {
        private readonly IDbContext _dbContext;

        public HealthReportRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<GetHelethReportsApiDTO.Reponse>>  GetAllHealthReportByMonth(int patienId ,int month, int year)
        {
            var p = new DynamicParameters();
            p.Add("@PatientId", patienId, DbType.Int32, ParameterDirection.Input);
            p.Add("@Month", month, DbType.Int32, ParameterDirection.Input);
            p.Add("@Year", year, DbType.Int32, ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<GetHelethReportsApiDTO.Reponse>("GetHelethReports", p, commandType: CommandType.StoredProcedure);
            return result;


        }

        public IEnumerable<HealthReport> GetAll()
        {
            throw new NotImplementedException();
        }

        public HealthReport GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(HealthReport t)
        {
            throw new NotImplementedException();
        }
        public bool Create(HealthReport t)
        {
            var p = new DynamicParameters();
            p.Add("@PatientId", t.PatientId, DbType.Int32, ParameterDirection.Input);
            p.Add("@Type", t.Type, DbType.String, ParameterDirection.Input);
            p.Add("@Value", t.Value, DbType.String, ParameterDirection.Input);
            try
            {
                var result = _dbContext.Connection.ExecuteAsync("HealthReportInsert", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
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
                var result = _dbContext.Connection.ExecuteAsync("HealthReportDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //public IEnumerable<HealthReport> GetAll()
        //{
        //    var result = _dbContext.Connection.Query<HealthReport>("HealthReportGetAll", commandType: CommandType.StoredProcedure);
        //    return result;
        //}

        //public HealthReport GetById(int id)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
        //    var result = _dbContext.Connection.QueryFirstOrDefault<HealthReport>("HealthReportSelect", p, commandType: CommandType.StoredProcedure);
        //    return result;
        //}

        //public bool Update(HealthReport t)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@Id"         , t.Id          , dbType: DbType.Int32  , ParameterDirection.Input);
        //    p.Add("@CreatedOn"  , t.CreatedOn   , DbType.DateTime       , ParameterDirection.Input);
        //    p.Add("@PatientId"  , t.PatientId   , DbType.Int32          , ParameterDirection.Input);
        //    p.Add("@TypeId"     , t.TypeId      , DbType.Int32          , ParameterDirection.Input);
        //    p.Add("@Value"      , t.Value       , DbType.Double         , ParameterDirection.Input);



        //    try
        //    {
        //        var result = _dbContext.Connection.Execute("HealthReportUpdate", p, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }

        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
