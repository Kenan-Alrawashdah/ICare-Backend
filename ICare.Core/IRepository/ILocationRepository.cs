using ICare.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Core.IRepository
{
    public interface ILocationRepository
    {
        bool AddLocation(Location location);
        bool DeleteLocation(int id);
        bool EditLocation(Location location);
        Task<Location> GetLocationById(int id);
        Task<IEnumerable<Location>> GetUserLocations(int userId);
    }
}
