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
                param.Add("@Quantity", cart.Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);

                _dbContext.Connection.Execute("CartInsert", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception erorr)
            {
                return false;
            }
        }

        public async Task<IEnumerable<GetCartItemsApiDTO.Response>> GetCartItems(int userId)
        {
            var param = new DynamicParameters();

            param.Add("@UserId", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var carts = await _dbContext.Connection.QueryAsync<GetCartItemsApiDTO.Response>("GetCartItems", param, commandType: CommandType.StoredProcedure);

            return carts;
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

        public async Task<bool> CheckItemExist(int patientId, int drugId)
        {
            var param = new DynamicParameters();
            param.Add("@DrugId", drugId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@PatientId", patientId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            int? exist = await _dbContext.Connection.ExecuteScalarAsync<int?>("CheckitemExistInCart", param, commandType: CommandType.StoredProcedure);
            if (exist != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
       // addOr Minus

        public bool AddQuantity(int cartId)
        {
            var param = new DynamicParameters();
            param.Add("@CartId", cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);

           _dbContext.Connection.ExecuteAsync("AddQuantity", param, commandType: CommandType.StoredProcedure);
          
            return true;

        }

        public bool MinusQuantity(int cartId)
        {
            var param = new DynamicParameters();
            param.Add("@CartId", cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _dbContext.Connection.ExecuteAsync("MinusQuantity", param, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool ChangeQuantity(int cartId, int Quantity)
        {
            var param = new DynamicParameters();
            param.Add("@CartId", cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("@Quantity", Quantity, dbType: DbType.Int32, direction: ParameterDirection.Input);


            _dbContext.Connection.ExecuteAsync("ChangeQuantity", param, commandType: CommandType.StoredProcedure);

            return true;
        }

        //public IEnumerable<Cart> GetAll()
        //{
        //    var carts = _dbContext.Connection.Query<Cart>("CartGetAll", commandType: CommandType.StoredProcedure);

        //    return carts;
        //}

        //public Cart GetById(int cartId)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@Id", cartId, dbType: DbType.Int32, direction: ParameterDirection.Input);

        //    var cart = _dbContext.Connection.QueryFirstOrDefault<Cart>("CartSelect", param, commandType: CommandType.StoredProcedure);

        //    return cart;
        //}

        //public bool Update(Cart cart)
        //{
        //    try
        //    {
        //        var param = new DynamicParameters();

        //        param.Add("@Id", cart.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@CreatedOn", cart.CreatedOn, dbType: DbType.DateTime, direction: ParameterDirection.Input);
        //        param.Add("@DrugId", cart.DrugId, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //        param.Add("@PatientId", cart.PatientId, dbType: DbType.Int32, direction: ParameterDirection.Input);




        //        _dbContext.Connection.Execute("CartUpdate", param, commandType: CommandType.StoredProcedure);
        //        return true;
        //    }
        //    catch (Exception erorr)
        //    {
        //        return false;
        //    }
        //}
    }
}
