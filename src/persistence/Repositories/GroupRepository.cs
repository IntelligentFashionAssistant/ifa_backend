﻿using application.persistence;
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
            var data = _appDbContext.Groups
                   .Include(group => group.Properties)
                    .Include(group => group.Category)
                   .ToList();

            return data;
        }

        public ICollection<Group> GetGroupByCategory(long id)
        {
            var data = _appDbContext.Groups.Where(g => g.CategoryId == id)
                   .Include(group => group.Properties)
                   .AsNoTracking()
                   .ToList();

            return data;
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
