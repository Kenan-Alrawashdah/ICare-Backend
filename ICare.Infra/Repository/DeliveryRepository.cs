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
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly IDbContext _dbContext;

        public DeliveryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Delivery delivery)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@CreatedOn", delivery.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@UserId", delivery.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("DeliveryInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }

        }

        public bool Delete(int deliveryId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", deliveryId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("DeliveryDelete", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public IEnumerable<Delivery> GetAll()
        {

            var deliverys = _dbContext.Connection.Query<Delivery>("DeliveryGetAll", commandType: CommandType.StoredProcedure);

            return deliverys;
        }

        public Delivery GetById(int id)
        {
            var delivery = _dbContext.Connection.QueryFirstOrDefault<Delivery>("DeliverySelect", commandType: CommandType.StoredProcedure);

            return delivery;
        }

        public bool Update(Delivery delivery)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@Id", delivery.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@CreatedOn", delivery.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@UserId", delivery.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("DeliveryUpdate", param, commandType: CommandType.StoredProcedure);

                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }

        }
    }
}
