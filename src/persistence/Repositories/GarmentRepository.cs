
using System.Collections.Generic;
using System.Linq;
using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace persistence.Repositories
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
                            .Include(g => g.Images)
                            .Include(g => g.Category)
                            .Include(g => g.Colors)
                            .AsNoTracking().ToList();
            return garments;
        }

        public Garment Create(Garment obj)
        {
            var garment = new Garment()
            {
                Brand = obj.Brand,
                CategoryId = obj.CategoryId,
                Description = obj.Description,
                Name = obj.Name,
                Price = obj.Price,
                //StoreId = obj.StoreId,
                Colors = obj.Colors.Select(color => new Color { Name = color.Name }).ToList(),
            };

             var listProperts = new List<Property>();
            foreach (var prop in obj.Properties)
            {
                var property = _appDbContext.Properties.Where(p => p.Id == prop.Id).Include(p => p.Category).SingleOrDefault();
                listProperts.Add(property);
            }

            foreach (var i in obj.Images)
            {
                garment.Images.Add(new Image() { Path =  i.Path,PropertyId = 1});
            }
            garment.Properties = listProperts;

            _appDbContext.Add(garment);
            _appDbContext.SaveChanges();

            return garment;
        }

        public Garment Update(Garment obj)
        {
            var garment = new Garment()
            {
                Id = obj.Id,
                Brand = obj.Brand,
                CategoryId = obj.CategoryId,
                Description = obj.Description,
                Name = obj.Name,
                Price = obj.Price,
                //StoreId = obj.StoreId,
                Colors = obj.Colors.Select(color => new Color { Name = color.Name }).ToList(),
            };

            var listProperts = new List<Property>();
            foreach (var prop in obj.Properties)
            {
                var property = _appDbContext.Properties.Where(p => p.Id == prop.Id).Include(p => p.Category).SingleOrDefault();
                listProperts.Add(property);
            }

            foreach (var i in obj.Images)
            {
                garment.Images.Add(new Image() { Path = i.Path, PropertyId = 1 });
            }
            garment.Properties = listProperts;
            _appDbContext.Update(garment);
            _appDbContext.SaveChanges();

            return garment;
        }

        public void DeleteById(long id)
        {
            _appDbContext.Remove(new Garment { Id = id });
            _appDbContext.SaveChanges();
        }

    }
}