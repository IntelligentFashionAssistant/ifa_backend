
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

        public ICollection<Garment> GetAll()
        {
            var garments = _appDbContext.Garments
                            .Include(g => g.Images)
                            .Include(g => g.Category)
                            .Include(g => g.Colors)
                            .Include(g => g.Properties)
                            .Include(g => g.Sizes)
                            .AsNoTracking().ToList();
            return garments;
        }

        public Garment GetById(long id)
        {
            var garment = _appDbContext.Garments
                          .Where(garment => garment.Id == id)
                          .Include(g => g.Properties)
                          .Include(g => g.Colors)
                          .Include(g => g.Images)
                          .Include(g => g.Users)
                          .Include(g => g.Category).Single();
            return garment;
        }

        public Garment GetUserById(long id)
        {
            var garment = _appDbContext.Garments
                         .Where(garment => garment.Id == id)
                         .Include(g => g.Colors)
                         .Include(g => g.Images)
                         .Include(g => g.Category)
                         .Include(g => g.Store)
                         .ThenInclude(s => s.Locations)
                         .Include(g => g.Store)
                         .ThenInclude(s => s.StoreFeedbacks)
                         .Single();
            return garment;
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
        public void RemoveUser(User user , long garmentId)
        {
            var g = _appDbContext.Garments.Single(g => g.Id == garmentId);

            g.Users.Remove(user);

            _appDbContext.SaveChanges();
        }
        public void AddUser(User user, long garmentId)
        {
            var g = _appDbContext.Garments.Single(g => g.Id == garmentId);

            g.Users.Add(user);

            _appDbContext.SaveChanges();
        }
        public bool UserExists(User user, long garmentId)
        {
            var g = _appDbContext.Garments.Include(g => g.Users).Single(g => g.Id == garmentId);

          return  g.Users.Any(u => u.Id == user.Id);

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
        public ICollection<Garment> GetGarmentFavoriteToUser(long userId)
        {
            var garments = _appDbContext.Garments
                            .Include(g => g.Users)
                            .Include(g => g.Images)
                            .Include(g => g.Category)
                            .Include(g => g.Colors)
                            .Include(g => g.Sizes)
                            .Where(g => g.Users.Any(user => user.Id == userId))
                            .AsNoTracking().ToList();

            return garments;                
        }

        public bool CheckGarmentIsLike(long garmentId, long userId)
        {
            var garments = _appDbContext.Garments
                          .Where(g => g.Id == garmentId)
                          .Include(g => g.Users)
                          .Single();

            return garments.Users.Any(u => u.Id == userId);
        }
    }
}