using Dapper;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ICare.Infra.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbContext _dbContext;

        public PatientRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;

        }

        public Patient GetPatientByUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("@userId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            try
            {
                var result = _dbContext.Connection.QueryFirstOrDefault<Patient>("GetPaitentByUserId", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> AddPatientDrugs(PatientDrugs patientDrug, List<DrugDoseTime> drugDoseTime)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn", patientDrug.CreatedOn, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@PatientId", patientDrug.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@StartDate", patientDrug.StartDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@EndDate", patientDrug.EndDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@DrugName", patientDrug.DrugName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.ExecuteScalar<int>("PatientDrugsInsert", p, commandType: CommandType.StoredProcedure);

            foreach (var item in drugDoseTime)
            {
                item.PatientDrugId = result;
               await CreateDrugDoseTime(item);
            }

            return true;
        }

        private async Task<bool> CreateDrugDoseTime(DrugDoseTime t)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn", t.CreatedOn, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@PatientDrugId", t.PatientDrugId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Time", t.Time, dbType: DbType.Time, direction: ParameterDirection.Input);
            try
            {
                var result = await _dbContext.Connection.ExecuteAsync("DrugDoseTimeInsert", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public bool Create(Patient t)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@CreatedOn", t.CreatedOn, DbType.DateTime, ParameterDirection.Input);
        //    p.Add("@UserId", t.UserId, DbType.Int32, ParameterDirection.Input);
        //    p.Add("@Liters", t.Liters, DbType.Double, ParameterDirection.Input);
        //    p.Add("@SubscriptionValidation", t.SubscriptionValidation, DbType.DateTime, ParameterDirection.Input);


        //    try
        //    {
        //        var result = _dbContext.Connection.Execute("PatientInsert", p, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        //public bool Delete(int id)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@Id", id, dbType: DbType.Int32, ParameterDirection.Input);

        //    try
        //    {
        //        var result = _dbContext.Connection.Execute("RolesDelete", p, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        //public IEnumerable<Patient> GetAll()
        //{
        //    var result = _dbContext.Connection.Query<Patient>("PatientGetAll", commandType: CommandType.StoredProcedure);
        //    return result;
        //}

        //public Patient GetById(int id)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
        //    var result = _dbContext.Connection.QueryFirstOrDefault<Patient>("PatientSelect", p, commandType: CommandType.StoredProcedure);
        //    return result;
        //}

        //public bool Update(Patient t)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@Id", t.Id, dbType: DbType.Int32, ParameterDirection.Input);
        //    p.Add("@CreatedOn", t.CreatedOn, DbType.DateTime, ParameterDirection.Input);
        //    p.Add("@UserId", t.UserId, DbType.Int32, ParameterDirection.Input);
        //    p.Add("@Liters", t.Liters, DbType.Double, ParameterDirection.Input);
        //    p.Add("@SubscriptionValidation", t.SubscriptionValidation, DbType.DateTime, ParameterDirection.Input);


        //    try
        //    {
        //        var result = _dbContext.Connection.Execute("BookUpdate", p, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }

        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
