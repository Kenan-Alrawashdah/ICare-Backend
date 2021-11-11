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
    public class SubscriptionTypeRepository : ISubscriptionTypeRepository
    {
        private readonly IDbContext _dbContext;

        public SubscriptionTypeRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(SubscribeType t)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn"              , t.CreatedOn               , DbType.DateTime   , ParameterDirection.Input);
            p.Add("@Type"                   , t.Type                    , DbType.String     , ParameterDirection.Input);
            p.Add("@SubscribePrice"         , t.SubscribePrice          , DbType.Double     , ParameterDirection.Input);
            p.Add("@SubscribeDescription"   , t.SubscribeDescription    , DbType.String     , ParameterDirection.Input);
            p.Add("@Days"                   , t.Days                    , DbType.Int32      , ParameterDirection.Input);


            try
            {
                var result = _dbContext.Connection.Execute("SubscribeTypeInsert", p, commandType: CommandType.StoredProcedure);
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
                var result = _dbContext.Connection.Execute("SubscribeTypeDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<SubscribeType> GetAll()
        {
            var result = _dbContext.Connection.Query<SubscribeType>("SubscriptionTypeGetAll", commandType: CommandType.StoredProcedure);
            return result;
        }

        public SubscribeType GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<SubscribeType>("SubscribeTypeSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(SubscribeType t)
        {
            var p = new DynamicParameters();
            p.Add("@Id"                   , t.Id                    , dbType: DbType.Int32  , ParameterDirection.Input);
            p.Add("@CreatedOn"            , t.CreatedOn             , DbType.DateTime       , ParameterDirection.Input);
            p.Add("@Type"                 , t.Type                  , DbType.String         , ParameterDirection.Input);
            p.Add("@SubscribePrice"       , t.SubscribePrice        , DbType.Double         , ParameterDirection.Input);
            p.Add("@SubscribeDescription" , t.SubscribeDescription  , DbType.String         , ParameterDirection.Input);
            p.Add("@Days"                 , t.Days                  , DbType.Int32          , ParameterDirection.Input);


            try
            {
                var result = _dbContext.Connection.Execute("SubscribeTypeUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
    }
}
