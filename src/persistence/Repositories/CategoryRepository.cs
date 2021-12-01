using System.Collections.Generic;
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
            var category = _appDbContext.Add(obj);
            _appDbContext.SaveChanges();
            //_appDbContext.Entry(obj).State = System.Data.Entity.EntityState.Detached;
            return new Category();
        }

        public Category Update(Category obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}