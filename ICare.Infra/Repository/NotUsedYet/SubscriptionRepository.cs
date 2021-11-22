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
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IDbContext _dbContext;

        public SubscriptionRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(Subscription t)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn"          , t.CreatedOn       , DbType.DateTime   , ParameterDirection.Input);
            p.Add("@PatientId"          , t.PatientId       , DbType.Int32      , ParameterDirection.Input);
            p.Add("@SubscribeTypeId"    , t.SubscribeTypeId , DbType.Int32      , ParameterDirection.Input);


            try
            {
                var result = _dbContext.Connection.Execute("SubscriptionInsert", p, commandType: CommandType.StoredProcedure);
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
            p.Add("@Id"     , id        , dbType: DbType.Int32      , ParameterDirection.Input);

            try
            {
                var result = _dbContext.Connection.Execute("SubscriptionDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Subscription> GetAll()
        {
            var result = _dbContext.Connection.Query<Subscription>("SubscriptionGetAll", commandType: CommandType.StoredProcedure);
            return result;
        }

        public Subscription GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<Subscription>("SubscriptionSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(Subscription t)
        {
            var p = new DynamicParameters();
            p.Add("@Id"                 , t.Id              , dbType: DbType.Int32  , ParameterDirection.Input);
            p.Add("@CreatedOn"          , t.CreatedOn       , DbType.DateTime       , ParameterDirection.Input);
            p.Add("@PatientId"          , t.PatientId       , DbType.Int32          , ParameterDirection.Input);
            p.Add("@SubscribeTypeId"    , t.SubscribeTypeId , DbType.Int32          , ParameterDirection.Input);


            try
            {
                var result = _dbContext.Connection.Execute("SubscriptionUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
    }
}
