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
    public class CartRepository : ICartRepository
    {
        private readonly IDbContext _dbContext;

        public CartRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Cart cart)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@CreatedOn", cart.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@DrugId", cart.DrugId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@PatientId", cart.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);




                _dbContext.Connection.Execute("CartInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public bool Delete(int cartId)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("CartDelete", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public IEnumerable<Cart> GetAll()
        {
            var carts = _dbContext.Connection.Query<Cart>("CartGetAll", commandType: CommandType.StoredProcedure);

            return carts;
        }

        public Cart GetById(int cartId)
        {
            var param = new DynamicParameters();
            param.Add("@Id", cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var cart = _dbContext.Connection.QueryFirstOrDefault<Cart>("CartSelect", param, commandType: CommandType.StoredProcedure);

            return cart;
        }

        public bool Update(Cart cart)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@Id", cart.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@CreatedOn", cart.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                param.Add("@DrugId", cart.DrugId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                param.Add("@PatientId", cart.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);




                _dbContext.Connection.Execute("CartUpdate", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }
    }
}
