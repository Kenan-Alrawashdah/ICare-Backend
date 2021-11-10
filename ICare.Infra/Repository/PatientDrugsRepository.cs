using Dapper;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ICare.Infra.Repository
{
    public class PatientDrugsRepository : ICRUDRepository<PatientDrugs>
    {
        private readonly IDbContext _DbContext;
        public PatientDrugsRepository(IDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public bool Create(PatientDrugs t)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn", t.CreatedOn, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@PatientId", t.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ScheduleId", t.ScheduleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@StartDate", t.StartDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@EndDate", t.EndDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@DrugName", t.DrugName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _DbContext.Connection.ExecuteAsync("PatientDrugsInsert", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _DbContext.Connection.ExecuteAsync("PatientDrugsDelete", p, commandType: CommandType.StoredProcedure);
            return true;
            
        }

        public IEnumerable<PatientDrugs> GetAll()
        {
            IEnumerable<PatientDrugs> result = _DbContext.Connection.Query<PatientDrugs>("PatientDrugsGetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public PatientDrugs GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
           var result = _DbContext.Connection.QueryFirstOrDefault<PatientDrugs>("PatientDrugsSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(PatientDrugs t)
        {
            var p = new DynamicParameters();
            p.Add("@Id", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CreatedOn", t.CreatedOn, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@PatientId", t.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ScheduleId", t.ScheduleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@StartDate", t.StartDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@EndDate", t.EndDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@DrugName", t.DrugName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _DbContext.Connection.ExecuteAsync("PatientDrugsUpdate", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
