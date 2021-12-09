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
    public class LocationRepository : ILocationRepository
    {
        private readonly IDbContext _dbContext;

        public LocationRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool AddLocation(Location location)
        {
            var p = new DynamicParameters();
            p.Add("@AddressName", location.AddressName, DbType.String, ParameterDirection.Input);
            p.Add("@UserId", location.UserId, DbType.String, ParameterDirection.Input);
            p.Add("@PhoneNumber", location.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@City", location.City, DbType.String, ParameterDirection.Input);
            p.Add("@ZipCode", location.ZipCode, DbType.String, ParameterDirection.Input);
            p.Add("@Details", location.Details, DbType.String, ParameterDirection.Input);
            p.Add("@Street", location.Street, DbType.String, ParameterDirection.Input);
            try
            {
                var result =_dbContext.Connection.ExecuteAsync("LocationInsert", p, commandType: CommandType.StoredProcedure);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Location>> GetUserLocations(int userId)
        {
            var p = new DynamicParameters();
            p.Add("@Id", userId, dbType: DbType.Int32, ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Location>("GetUserLocations", p, commandType: CommandType.StoredProcedure);
            return result;

        }
        public async Task<Location> GetLocationByOrderId(int orderId)
        {
            var p = new DynamicParameters();
            p.Add("@OrderId", orderId, dbType: DbType.Int32, ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<Location>("GetLocationByOrderId", p, commandType: CommandType.StoredProcedure);
            return result;

        }

        public async Task<Location> GetLocationById(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, ParameterDirection.Input);
            var result = await _dbContext.Connection.QuerySingleAsync<Location>("LocationSelect", p, commandType: CommandType.StoredProcedure);
            return result;
        }

        public bool EditLocation(Location location)
        {
            var p = new DynamicParameters();
            p.Add("@Id", location.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("@AddressName", location.AddressName, DbType.String, ParameterDirection.Input);
            p.Add("@PhoneNumber", location.PhoneNumber, DbType.String, ParameterDirection.Input);
            p.Add("@City", location.City, DbType.String, ParameterDirection.Input);
            p.Add("@ZipCode", location.ZipCode, DbType.String, ParameterDirection.Input);
            p.Add("@Details", location.Details, DbType.String, ParameterDirection.Input);
            p.Add("@Street", location.Street, DbType.String, ParameterDirection.Input);
            try
            {
                var result = _dbContext.Connection.ExecuteAsync("LocationUpdate", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteLocation (int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            try
            {
                var result = _dbContext.Connection.ExecuteAsync("LocationDelete", p, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
