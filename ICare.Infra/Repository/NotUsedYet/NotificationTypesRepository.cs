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
    public class NotificationTypesRepository : INotificationTypesRepository
    {
        private readonly IDbContext _dbContext;

        public NotificationTypesRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(NotificationTypes t)
        {
            var p = new DynamicParameters();
            p.Add("@CreatedOn"  , t.CreatedOn   , DbType.DateTime   , ParameterDirection.Input);
            p.Add("@Type"       , t.Type        , DbType.String     , ParameterDirection.Input);



            try
            {
                var result = _dbContext.Connection.Execute("NotificationTypesInsert", p, commandType: CommandType.StoredProcedure);
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
                var result = _dbContext.Connection.Execute("NotificationTypesDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<NotificationTypes> GetAll()
        {
            var result = _dbContext.Connection.Query<NotificationTypes>("GetAllNotificationTypes", commandType: CommandType.StoredProcedure);
            return result;
        }

        public NotificationTypes GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            var result = _dbContext.Connection.QueryFirstOrDefault<NotificationTypes>("NotificationTypesSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool Update(NotificationTypes t)
        {
            var p = new DynamicParameters();
            p.Add("@Id"         , t.Id          , dbType: DbType.Int32  , ParameterDirection.Input);
            p.Add("@CreatedOn"  , t.CreatedOn   , DbType.DateTime       , ParameterDirection.Input);
            p.Add("@Type"       , t.Type        , DbType.Int32          , ParameterDirection.Input);



            try
            {
                var result = _dbContext.Connection.Execute("NotificationTypesUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
    }
}
