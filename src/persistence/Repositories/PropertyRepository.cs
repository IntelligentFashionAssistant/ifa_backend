using System.Collections.Generic;
using System.Linq;
using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Propertys.Repositories
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
      
        public IDictionary<string, ICollection<Property>> GetAllPropertyWithGroup()
        {
            // return  _appDbContext.Properties.Include(property => property.Group)
            //     .GroupBy(property => property.Group.Name)
            //     .ToDictionary(el => el.Key, el => el.ToList());
            return null;
        }

        public ICollection<Property> GetAll()
        {

            return _appDbContext.Properties
                   .Include(g => g.Group)
                   .ToList(); 
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

        public ICollection<Property> GetPropertysByGroupId(long groupId)
        {
            var data = _appDbContext.Properties.
                     Where(p => p.GroupId == groupId).
                     AsNoTracking().ToList();
            return data;
        }

    }
}