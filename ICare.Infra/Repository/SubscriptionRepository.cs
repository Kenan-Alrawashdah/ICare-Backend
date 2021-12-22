using Dapper;
using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ICare.Infra.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IDbContext _dbContext;

        public SubscriptionRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool SubscriptionInsert(int patientId , int subscriptionId)
        {
            var p = new DynamicParameters();
            p.Add("@PatientId", patientId, DbType.Int32, ParameterDirection.Input);
            p.Add("@SubscribeTypeId", subscriptionId, DbType.Int32, ParameterDirection.Input);

            try
            {
                var result =  _dbContext.Connection.ExecuteAsync("SubscriptionInsert", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<SubscribeType>> GetAll()
        {
            var result = await _dbContext.Connection.QueryAsync<SubscribeType>("GetTypes", commandType: CommandType.StoredProcedure);
            return result;
        }


        //public async Task<bool> DeletePatientSubscription(int id)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@PatientId", id, dbType: DbType.Int32, ParameterDirection.Input);

        //    try
        //    {
        //        var result = await _dbContext.Connection.ExecuteAsync("SubscriptionDelete", p, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
        //public async Task<IEnumerable<GetAllPatientSubscriptionDTO>> GetAllPatientSubscription()
        //{
        //    var result = _dbContext.Connection.Query<GetAllPatientSubscriptionDTO>("SubscriptionGetAll", commandType: CommandType.StoredProcedure);
        //    return result;
        //}

        //public async Task<Subscription> GetByPatientId(int id)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@PatientId", id, DbType.Int32, ParameterDirection.Input);

        //    var result = _dbContext.Connection.QueryFirstOrDefault<Subscription>("SubscriptionSelect", p, commandType: CommandType.StoredProcedure);

        //    return result;
        //}

        //public async Task<Payment> SubscriptionPayment(SubscriptionPaymentDTO.Request request)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@CardNumber", request.CardNumber, DbType.Int32, ParameterDirection.Input);
        //    p.Add("@Expirydate", request.Expirydate, DbType.String, ParameterDirection.Input);
        //    p.Add("@cvcCode", request.cvcCode, DbType.Int32, ParameterDirection.Input);
        //    p.Add("@CardName", request.CardName, DbType.String, ParameterDirection.Input);

        //    var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<Payment>("SubscriptionSelect", p, commandType: CommandType.StoredProcedure);
        //    return result;


        //}

        //public async Task<bool> UpdatePatientSubscription(UpdatePatientSubscriptionDTO.Request request)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@PatientId", request.PatientId, DbType.Int32, ParameterDirection.Input);
        //    p.Add("@SubscribeTypeId", request.SubscribeTypeId, DbType.Int32, ParameterDirection.Input);

        //    try
        //    {
        //        var result = await _dbContext.Connection.ExecuteAsync("SubscriptionUpdate", p, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }

        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

    }
}
