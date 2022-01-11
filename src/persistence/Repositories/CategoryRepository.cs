using System.Collections.Generic;
using System.Linq;
using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Propertys.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Category GetById(long id)
        {
             
            return _appDbContext.Categorys.Single(category => category.Id == id);
        }

        public ICollection<Category> GetAll()
        {
            return _appDbContext.Categorys
                   .Include(c => c.Groups)
                   .ToList();
        }

        public Category Create(Category obj)
        {
             _appDbContext.Add(obj);
            _appDbContext.SaveChanges();
            
            return obj;
        }

        public Category Update(Category obj)
        {
            _appDbContext.Update(obj);
            _appDbContext.SaveChanges();

            return obj ;
        }

        public void DeleteById(long id)
        {
            _appDbContext.Remove(new Category {Id = id});
            _appDbContext.SaveChanges();
        }
    }
}