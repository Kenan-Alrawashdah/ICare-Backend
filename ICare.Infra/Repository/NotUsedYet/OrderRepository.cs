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
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _dbContext;

        public OrderRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Create(Order order)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@CreatedOn", order.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@DeliveryId", order.DeliveryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@TotalPrice", order.TotalPrice, dbType: DbType.Double, direction: ParameterDirection.Input);
                param.Add("@PatientId", order.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@StatusId", order.StatusId, dbType: DbType.Int32, direction: ParameterDirection.Input);


                _dbContext.Connection.Execute("OrderInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public bool Delete(int orderId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", orderId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("OrderDelete", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Connection.Query<Order>("OrderGetAll", commandType: CommandType.StoredProcedure);

            return orders;
        }

        public Order GetById(int orderId)
        {
            var param = new DynamicParameters();
            param.Add("@Id", orderId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var order = _dbContext.Connection.QueryFirstOrDefault<Order>("OrderSelect",param,  commandType: CommandType.StoredProcedure);

            return order;
        }

        public bool Update(Order order)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@Id", order.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@CreatedOn", order.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@DeliveryId", order.DeliveryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@TotalPrice", order.TotalPrice, dbType: DbType.Double, direction: ParameterDirection.Input);
                param.Add("@PatientId", order.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@StatusId", order.StatusId, dbType: DbType.Int32, direction: ParameterDirection.Input);


                _dbContext.Connection.Execute("OrderUpdate", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }
    }
}
