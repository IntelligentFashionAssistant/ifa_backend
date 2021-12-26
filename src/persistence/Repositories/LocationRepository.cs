using application.persistence;
using domain.Entitys;
using persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _appDbContext;

        public LocationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Location Create(Location obj)
        {
            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();

            return obj;
        }

        public void DeleteById(long id)
        {
            _appDbContext.Remove(new Location { Id = id });
            _appDbContext.SaveChanges();
        }


        public ICollection<Location> GetAll()
        {
            return _appDbContext.Locations.ToList();
        }

        public Location GetById(long id)
        {
            return _appDbContext.Locations.Single(location => location.Id == id);
        }

        public Location Update(Location obj)
        {
            _appDbContext.Update(obj);
            _appDbContext.SaveChanges();

            return obj;
        }

        public ICollection<Location> GetLocationsToStore(long storeId) {
        
          return _appDbContext.Locations.Where(locaton => locaton.StoreId == storeId).ToList();        
        }
    }
}
