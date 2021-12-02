using System.Collections.Generic;
using System.Linq;
using application.persistence;
using domain.Entitys;

namespace repository.Repositories
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
             
            return _appDbContext.Categorys.SingleOrDefault(category => category.Id == id);
        }

        public ICollection<Category> GetAll()
        {
            return _appDbContext.Categorys.ToList();
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