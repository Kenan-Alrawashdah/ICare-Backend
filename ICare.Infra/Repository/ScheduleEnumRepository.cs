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
    public class ScheduleEnumRepository : IScheduleEnumRepository
    {
        private readonly IDbContext _DbContext;
        public ScheduleEnumRepository(IDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public bool Create(ScheduleEnum t)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn", t.CreatedOn, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@ValueName", t.ValueName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _DbContext.Connection.ExecuteAsync("ScheduleEnumInsert", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _DbContext.Connection.ExecuteAsync("ScheduleEnumDelete", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public IEnumerable<ScheduleEnum> GetAll()
        {
            IEnumerable<ScheduleEnum> result = _DbContext.Connection.Query<ScheduleEnum>("ScheduleEnumGetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ScheduleEnum GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _DbContext.Connection.QueryFirstOrDefault <ScheduleEnum>("ScheduleEnumSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(ScheduleEnum t)
        {
            var p = new DynamicParameters();
            p.Add("@Id", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CreatedOn", t.CreatedOn, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@ValueName", t.ValueName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _DbContext.Connection.ExecuteAsync("ScheduleEnumUpdate", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
