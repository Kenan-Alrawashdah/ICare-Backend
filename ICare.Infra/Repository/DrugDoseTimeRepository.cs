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
   
    public class DrugDoseTimeRepository : IDrugDoseTimeRepository
    {
        private readonly IDbContext _DbContext;
        public DrugDoseTimeRepository(IDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public bool Create(DrugDoseTime t)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn", t.CreatedOn, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@PatientDrugId", t.PatientDrugId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Time", t.Time, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = _DbContext.Connection.ExecuteAsync("DrugDoseTimeInsert", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _DbContext.Connection.ExecuteAsync("DrugDoseTimeDelete", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public IEnumerable<DrugDoseTime> GetAll()
        {

            IEnumerable<DrugDoseTime> result = _DbContext.Connection.Query<DrugDoseTime>("DrugDoseTimeGetAll", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public DrugDoseTime GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _DbContext.Connection.QueryFirstOrDefault<DrugDoseTime>("DrugDoseTimeSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(DrugDoseTime t)
        {
            var p = new DynamicParameters();
            p.Add("@Id", t.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CreatedOn", t.CreatedOn, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@PatientDrugId", t.PatientDrugId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Time", t.Time, dbType: DbType.Date, direction: ParameterDirection.Input); 
            var result = _DbContext.Connection.ExecuteAsync("DrugDoseTimeUpdate", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
