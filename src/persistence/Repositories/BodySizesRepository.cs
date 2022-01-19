using application.persistence;
using domain.Entitys;
using Propertys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propertys.Repositories
{
    public class BodySizesRepository : IBodySizesRepository
    {
        private readonly AppDbContext _appDbContext;

        public BodySizesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public BodySize Create(BodySize obj)
        {
            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();

            return obj;    
        }

        public void DeleteById(long id)
        {
            _appDbContext.Remove(new BodySize { Id = id });
            _appDbContext.SaveChanges();

        }

        public ICollection<BodySize> GetAll()
        {
            return _appDbContext.BodySizes.ToList();
        }

        public BodySize GetById(long id)
        {
            return _appDbContext.BodySizes.Single(bodySizes => bodySizes.Id == id);
        }

        public BodySize Update(BodySize obj)
        {
            _appDbContext.Update(obj);
            _appDbContext.SaveChanges();

            return obj;
        }
    }
}
