using Dapper;
using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            p.Add("@CreatedOn", patientDrug.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@PatientId", patientDrug.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@StartDate", patientDrug.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@EndDate", patientDrug.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
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


        public async Task<IEnumerable<MyDrugsApiDto.Drug>> GetMyDrugs(int patientId)
        {
            var p = new DynamicParameters();
            p.Add("@pathientId", patientId, DbType.Int32, ParameterDirection.Input);
            var result = (await _dbContext.Connection.QueryAsync<MyDrugsApiDto.Drug>("GetMyDrugs", p, commandType: CommandType.StoredProcedure)).ToList();
            var count = -1;
            foreach (var item in result)
            {
                count++;
                var p2 = new DynamicParameters();
                p2.Add("@Id", item.Id, DbType.Int32, ParameterDirection.Input);


                var doseTime = (await _dbContext.Connection.QueryAsync<TimeSpan>("GetDrugDoseTimeByPatientDrugId", p2, commandType: CommandType.StoredProcedure)).ToList();

                result[count].Times = new List<String>();


                foreach (var item2 in doseTime)
                {
                    result[count].Times.Add(item2.ToString());

                }
            }
            return result;

        }


        public async Task<EditDrugApiDTO.Response> GetDrug(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var drug = await _dbContext.Connection.QueryFirstOrDefaultAsync<PatientDrugs>("GetPatientDrugById", p, commandType: CommandType.StoredProcedure);
            var doseTime = (await _dbContext.Connection.QueryAsync<TimeSpan>("GetDrugDoseTimeByPatientDrugId", p, commandType: CommandType.StoredProcedure)).ToList();
            var result = new EditDrugApiDTO.Response
            {
                DrugName = drug.DrugName,
                EndDate = drug.EndDate
            };
            var count = 1;
            foreach (var item in doseTime)
            {
                if (count == 1)
                {
                    result.drugDoseTime1 = item.ToString();
                    count++;
                }
                else if (count == 2)
                {
                    result.drugDoseTime2 = item.ToString();
                    count++;
                }
                else if (count == 3)
                {
                    result.drugDoseTime3 = item.ToString();
                    count++;
                }
                else if (count == 4)
                {
                    result.drugDoseTime4 = item.ToString();
                    count++;
                }

            }

            return result;
        }


        public async Task<bool> EditPatientDrugs(PatientDrugs patientDrug, List<DrugDoseTime> drugDoseTime)
        {
            var p = new DynamicParameters();

            p.Add("@Id", patientDrug.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@EndDate", patientDrug.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@DrugName", patientDrug.DrugName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.ExecuteScalar<int>("PatientDrugsUpdate", p, commandType: CommandType.StoredProcedure);

            var e = new DynamicParameters();
            e.Add("@PatientDrugsId", patientDrug.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("DeleteDrugDoseTime", e, commandType: CommandType.StoredProcedure);
            foreach (var item in drugDoseTime)
            {
                item.PatientDrugId = result;
                await CreateDrugDoseTime(item);
            }
            return true;
        }

        public async Task<bool> InsertPDFData(InsertPDFDataHealthReportDTO.Request request)
        {
            var p = new DynamicParameters();
            p.Add("@PatientId", request.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CreatedOn", request.CreatedOn, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@CheckUpName", request.CheckUpName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@BloodType", request.BloodType, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@BloodSugarLevel", request.BloodSugarLevel, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CheckUpDate", request.CheckUpDate, dbType: DbType.String, direction: ParameterDirection.Input);
            try
            {
                var result = await _dbContext.Connection.ExecuteAsync("InsertPDFData", p, commandType: CommandType.StoredProcedure);
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
