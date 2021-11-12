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
    public class OrderDrugsRepository : IOrderDrugsRepository
    {
        private readonly IDbContext _dbContext;

        public OrderDrugsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(OrderDrugs orderDrugs)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@CreatedOn", orderDrugs.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@OrderId", orderDrugs.OrderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@DrugsId", orderDrugs.DrugsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@Quantity", orderDrugs.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("OrderDrugsInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public bool Delete(int orderDrugsId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", orderDrugsId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("OrderDrugsDelete", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public IEnumerable<OrderDrugs> GetAll()
        {
            var orderDrugs = _dbContext.Connection.Query<OrderDrugs>("OrderDrugsGetAll", commandType: CommandType.StoredProcedure);

            return orderDrugs;
        }

        public OrderDrugs GetById(int orderDrugsId)
        {
            var param = new DynamicParameters();
            param.Add("@Id", orderDrugsId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var orderDrugs = _dbContext.Connection.QueryFirstOrDefault<OrderDrugs>("OrderDrugsSelect", param, commandType: CommandType.StoredProcedure);

            return orderDrugs;
        }

        public bool Update(OrderDrugs orderDrugs)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@Id", orderDrugs.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@CreatedOn", orderDrugs.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@OrderId", orderDrugs.OrderId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@DrugsId", orderDrugs.DrugsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@Quantity", orderDrugs.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("OrderDrugsUpdate", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }
    }
}
