using System.Collections.Generic;
using System.Linq;
using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace repository.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext _appDbContext;

        public PropertyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Property GetById(long id)
        {
            var property = _appDbContext.Properties.SingleOrDefault(property => property.Id == id);

            return property;
        }
        
        // g1 s1
        // g1 s2 
        public IDictionary<string, ICollection<Property>> GetAllPropertyWithGroup()
        {
            // return  _appDbContext.Properties.Include(property => property.Group)
            //     .GroupBy(property => property.Group.Name)
            //     .ToDictionary(el => el.Key, el => el.ToList());
            return null;
        }

        public ICollection<Property> GetAll()
        {
            return _appDbContext.Properties.Include(g => g.GroupId).ToList();
        }
        public Property Create(Property obj)
        {
            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();

            return obj;
        }

        public Property Update(Property obj)
        {
            _appDbContext.Update(obj);
            _appDbContext.SaveChanges();

            return obj;
        }

        public void DeleteById(long id)
        {
            _appDbContext.Remove(new Property { Id = id });
            _appDbContext.SaveChanges();
        }

       
    }
}