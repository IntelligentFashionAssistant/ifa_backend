
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
                            .Include(g => g.Properties)
                            .Include(g => g.Store)
                            .ThenInclude(s => s.User)
                            .Include(g => g.Store)
                            .ThenInclude(s => s.Locations)
                            .Include(g => g.Store)
                            .ThenInclude(s => s.StoreFeedbacks)
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
                StoreId = obj.StoreId,
            };

            var listProperts = new List<Property>();
            foreach (var prop in obj.Properties)
            {
                listProperts.Add(_appDbContext.Properties.Single(p => p.Id == prop.Id));
            }
            garment.Properties = listProperts;

            var sizes = new List<Size>();
            foreach (var size in obj.Sizes)
            {
                sizes.Add(_appDbContext.Sizes.Single(s => s.Name == size.Name));
            }
            garment.Sizes = sizes;
            
            
            var colors = new List<Color>();
            foreach (var color in obj.Colors)
            {
                colors.Add(_appDbContext.Colors.Single(s => s.Name == color.Name));
            }
            garment.Colors= colors;

            foreach (var i in obj.Images)
            {
                garment.Images.Add(new Image() { Path =  i.Path});
            }
            

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
                StoreId = obj.StoreId
            };

            var listProperts = new List<Property>();
            foreach (var prop in obj.Properties)
            {
                var property = _appDbContext.Properties.Where(p => p.Id == prop.Id).SingleOrDefault();
                listProperts.Add(property);
            }
            garment.Properties = listProperts;

            var sizes = new List<Size>();
            foreach (var size in obj.Sizes)
            {
                sizes.Add(_appDbContext.Sizes.Single(s => s.Name == size.Name));
            }
            garment.Sizes = sizes;
            
            
            var colors = new List<Color>();
            foreach (var color in obj.Colors)
            {
                sizes.Add(_appDbContext.Sizes.Single(s => s.Name == color.Name));
            }
            garment.Colors= colors;
            
            foreach (var i in obj.Images)
            {
                garment.Images.Add(new Image() { Path = i.Path, PropertyId = 1 });
            }
            
            
            _appDbContext.Update(garment);
            _appDbContext.SaveChanges();

            return garment;
        }

        public void DeleteById(long id)
        {
            _appDbContext.Remove(new Garment { Id = id });
            _appDbContext.SaveChanges();
        }

        public ICollection<Color> GetColors()
        {
            return _appDbContext.Colors.AsNoTracking().ToList();
        }

        public ICollection<Size> GetSizeByCategory(long categoryId)
        {

            return _appDbContext.Sizes
                   .Where(Size => Size.CategoryId == categoryId)
                   .AsNoTracking()
                   .ToList();
        }

    }
}