using System.Collections.Generic;
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

        public ICollection<Property> GetAllPropertyWithGroup()
        {
            var propertys = _appDbContext.Properties.Include(g => g.Group).
                  GroupBy(p => p.Group.Name)
                 .Select(group => new {key = group.Key, data = group.ToList() }).ToList();

            return (ICollection<Property>)propertys;             
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