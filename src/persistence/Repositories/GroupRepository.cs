using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propertys.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _appDbContext;

        public GroupRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Group Create(Group obj)
        {
            var listCategorys = new List<Category>();
            foreach (var category in obj.Categories)
            {
                listCategorys.Add(_appDbContext.Categorys.Single(c => c.Id == category.Id));
            }
             obj.Categories = listCategorys;

            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();

            return obj;
        }
        public Group Update(Group obj)
        {
            var g = _appDbContext.Groups.Where(g => g.Id == obj.Id).Include(g => g.Categories).Single();
            if (obj.Categories.ToList().Count > 0)
            {
                g.Categories.Clear();
            }
            foreach (var category in obj.Categories)
            {
                g.Categories.Add(_appDbContext.Categorys.Single(c => c.Id == category.Id));
            }
            g.Name = obj.Name;
            g.Description = obj.Description;
                

            _appDbContext.SaveChanges();

            return g;
        }
        public void DeleteById(long id)
        {
            _appDbContext.Remove(new Group { Id = id });
            _appDbContext.SaveChanges();
        }

        public ICollection<Group> GetAll()
        {
            var data = _appDbContext.Groups
                   .Include(group => group.Properties)
                    .Include(group => group.Categories)
                   .ToList();

            return data;
        }

        public ICollection<Group> GetGroupByCategory(long id)
        {
            return _appDbContext.Categorys
                .Include(category => category.Groups)
                .ThenInclude(group => group.Properties)
                .Single(category => category.Id == id)
                .Groups;
        }
        
        
        public Group GetById(long id)
        {
           return _appDbContext.Groups
                  .Include(g => g.Properties)
                  .Include(g => g.Categories)
                  .Single(group => group.Id == id);
        }

       
    }
}
