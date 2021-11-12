using Dapper;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ICare.Infra.Repository
{
    public class PatientRepository : IPatientRepository    
    {
        private readonly IDbContext _dbContext;
        private readonly IUserServices _userServices;

        public PatientRepository(IDbContext dbContext,IUserServices userServices)
        {
            this._dbContext = dbContext;
            this._userServices = userServices;
        }
        public bool Create(Patient t)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn"                  , t.CreatedOn                , DbType.DateTime   , ParameterDirection.Input);
            p.Add("@UserId"                     , t.UserId                   , DbType.Int32      , ParameterDirection.Input);
            p.Add("@Liters"                     , t.Liters                   , DbType.Double     , ParameterDirection.Input);
            p.Add("@SubscriptionValidation"     , t.SubscriptionValidation   , DbType.DateTime   , ParameterDirection.Input);


            try
            {
                var result = _dbContext.Connection.Execute("PatientInsert", p, commandType: CommandType.StoredProcedure);
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
                var result = _dbContext.Connection.Execute("RolesDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Patient> GetAll()
        {
            var result = _dbContext.Connection.Query<Patient>("PatientGetAll", commandType: CommandType.StoredProcedure);
            return result;
        }

        public Patient GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<Patient>("PatientSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(Patient t)
        {
            var p = new DynamicParameters();
            p.Add("@Id"                     , t.Id                          , dbType: DbType.Int32    , ParameterDirection.Input);
            p.Add("@CreatedOn"              , t.CreatedOn                   , DbType.DateTime         , ParameterDirection.Input);
            p.Add("@UserId"                 , t.UserId                      , DbType.Int32            , ParameterDirection.Input);
            p.Add("@Liters"                 , t.Liters                      , DbType.Double           , ParameterDirection.Input);
            p.Add("@SubscriptionValidation" , t.SubscriptionValidation      , DbType.DateTime         , ParameterDirection.Input);


            try
            {
                var result = _dbContext.Connection.Execute("BookUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
    }
}
