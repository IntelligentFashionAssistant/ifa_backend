using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence.Repositories
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
            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();

            return obj;
        }

        public void DeleteById(long id)
        {
            _appDbContext.Remove(new Group { Id = id });
            _appDbContext.SaveChanges();
        }

        public ICollection<Group> GetAll()
        {
            return _appDbContext.Groups.Include(group => group.Properties).ToList();
        }

        public Group GetById(long id)
        {
           return _appDbContext.Groups.SingleOrDefault(group => group.Id == id);
        }

        public Group Update(Group obj)
        {
            _appDbContext.Update(obj);
            _appDbContext.SaveChanges();

            return obj;
        }
    }
}
