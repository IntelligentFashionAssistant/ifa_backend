
using System.Collections.Generic;
using System.Linq;
using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Propertys.Repositories
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
            var garment = _appDbContext.Garments
                          .Where(garment => garment.Id == id)
                          .Include(g => g.Properties)
                          .Include(g => g.Colors)
                          .Include(g => g.Images)
                          .Include(g => g.Category).Single();
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
                sizes.Add(_appDbContext.Sizes.Single(s => s.Id == size.Id));
            }
            garment.Sizes = sizes;
            
            
            var colors = new List<Color>();
            foreach (var color in obj.Colors)
            {
                colors.Add(_appDbContext.Colors.Single(s => s.Id == color.Id));
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
                var garment = _appDbContext.Garments.
                           Where(g => g.Id == obj.Id)
                           .Include(g => g.Images)
                           .Include(g => g.Properties)
                           .Include(g => g.Colors)
                           .Include(g => g.Sizes)
                           .Single();



            garment.Brand = obj.Brand;
            garment.Description =  obj.Description;
            garment.Name =obj.Name ;
            garment.Price = obj.Price;
            garment.CategoryId = obj.CategoryId;
            garment.Properties =obj.Properties ;


            if (obj.Properties.ToList().Count > 0)
            {
                garment.Properties.Clear();
            }

            foreach (var prop in obj.Properties)
            {
                garment.Properties.Add(_appDbContext.Properties.Single(p => p.Id == prop.Id));
            }
            if (obj.Sizes.ToList().Count > 0)
            {
                garment.Sizes.Clear();
            }
            foreach (var size in obj.Sizes)
            {
                garment.Sizes.Add(_appDbContext.Sizes.Single(s => s.Id == size.Id));
            }


            if (obj.Colors.ToList().Count > 0)
            {
                garment.Colors.Clear();
            }
            foreach (var color in obj.Colors)
            {
                garment.Colors.Add(_appDbContext.Colors.Single(s => s.Id == color.Id));
            }

            if (obj.Images.ToList().Count > 0)
            {
                garment.Images.Clear();
            }
            foreach (var i in obj.Images)
            {
                garment.Images.Add(new Image() { Path = i.Path });
            }


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