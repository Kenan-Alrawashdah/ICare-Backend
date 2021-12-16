using Dapper;
using ICare.Core.ApiDTO;
using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _dbContext;

        public OrderRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Order order,List<int> cartIds)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@TotalPrice", order.TotalPrice, dbType: DbType.Double, direction: ParameterDirection.Input);
                param.Add("@PatientId", order.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@LocationId", order.LocationId, dbType: DbType.Int32, direction: ParameterDirection.Input);


                var orderId = await _dbContext.Connection.ExecuteScalarAsync<int>("OrderInsert", param, commandType: CommandType.StoredProcedure);
                foreach (var item in cartIds)
                {
                    CreateOrderDrugs(item, orderId);
                }
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        private bool CreateOrderDrugs(int cartId,int orderId)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@OrderId", orderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@CartId", cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("OrderDrugsInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        

        public async Task<IEnumerable<PaitentOrderApiDTO.Response>> GetPatientOrders(int patientID)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@PatientId", patientID, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result=await  _dbContext.Connection.QueryAsync<PaitentOrderApiDTO.Response>("GetUserOrder", param, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception erorr)
            {
                return null;
            }
        }

        public async Task<IEnumerable<GetAllOpenOredersApiDTO.Response>> GetAllOpenOrders()
        {
            var result = await _dbContext.Connection.QueryAsync<GetAllOpenOredersApiDTO.Response>("GetOpenOrders", commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<OrderDrugsApiDTO.Response>> GetOrderDrugs(int orderId)
        {
            var param = new DynamicParameters();
            param.Add("@Id", orderId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<OrderDrugsApiDTO.Response>("GetOrderDrugs", param, commandType: CommandType.StoredProcedure);

            return result;
        }

        public bool SetOrderAsCanceled(int orderId)
        {
            var p = new DynamicParameters();
            p.Add("@Id", orderId, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("SetOrderAsCanceled", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool SetOrderAsPlaced(int orderId)
        {
            var p = new DynamicParameters();
            p.Add("@Id", orderId, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.ExecuteAsync("SetOrderAsPlaced", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        //public bool Delete(int orderId)
        //{
        //    try
        //    {
        //        var param = new DynamicParameters();
        //        param.Add("@Id", orderId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //        _dbContext.Connection.Execute("OrderDelete", param, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception erorr)
        //    {
        //        return false;
        //    }
        //}

        //public IEnumerable<Order> GetAll()
        //{
        //    var orders = _dbContext.Connection.Query<Order>("OrderGetAll", commandType: CommandType.StoredProcedure);

        //    return orders;
        //}

        //public Order GetById(int orderId)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@Id", orderId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    var order = _dbContext.Connection.QueryFirstOrDefault<Order>("OrderSelect",param,  commandType: CommandType.StoredProcedure);

        //    return order;
        //}

        //public bool Update(Order order)
        //{
        //    try
        //    {
        //        var param = new DynamicParameters();

        //        param.Add("@Id", order.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@CreatedOn", order.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        //        param.Add("@DeliveryId", order.DeliveryId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@TotalPrice", order.TotalPrice, dbType: DbType.Double, direction: ParameterDirection.Input);
        //        param.Add("@PatientId", order.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@StatusId", order.StatusId, dbType: DbType.Int32, direction: ParameterDirection.Input);


        //        _dbContext.Connection.Execute("OrderUpdate", param, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception erorr)
        //    {
        //        return false;
        //    }
        //}
    }
}
