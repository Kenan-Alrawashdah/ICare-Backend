using ICare.Core.Data;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using ICare.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Infra.Services
{
    public class LocationSevices : ILocationSevices
    {
        private readonly ILocationRepository _locationRepository;

        public LocationSevices(ILocationRepository locationRepository)
        {
            this._locationRepository = locationRepository;
        }

        public bool AddLocation(Location location)
        {
            return _locationRepository.AddLocation(location);
        }
        public async Task<IEnumerable<Location>> GetUserLocations(int userId)
        {
            return await _locationRepository.GetUserLocations(userId);

        }
        public async Task<Location> GetLocationById(int id)
        {
            return await _locationRepository.GetLocationById(id);
        }

        public bool EditLocation(Location location)
        {
            return _locationRepository.EditLocation(location);
        }
        public bool DeleteLocation(int id)
        {
            return _locationRepository.DeleteLocation(id);

        }

    }
}
