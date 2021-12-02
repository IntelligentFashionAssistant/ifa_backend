
using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace repository.Repositories
{
    public class GarmentRepository : IGarmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public GarmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Garment GetById(long id)
        {
            var garment = _appDbContext.Garments.SingleOrDefault(garment => garment.Id == id);

            return garment;
        }

        public ICollection<Garment> GetAll()
        {
            var garments = _appDbContext.Garments
                            .Include(g => g.Images).AsNoTracking().ToList();
            return garments;
        }

        public Garment Create(Garment obj)
        {
            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();

            return obj;
        }

        public Garment Update(Garment obj)
        {
            _appDbContext.Update(obj);
            _appDbContext.SaveChanges();

            return obj;
        }

        public void DeleteById(long id)
        {
            _appDbContext.Remove(new Garment { Id = id });
            _appDbContext.SaveChanges();
        }

        public void RateGarment(PropertyFeedback obj)
        {
            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();
        }
    }
}