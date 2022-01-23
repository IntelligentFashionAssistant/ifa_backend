using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Propertys;

namespace application.services;

public class SizeRepository : ISizeRepository
{
    
     private readonly AppDbContext _appDbContext;
    
    public SizeRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
        
    
    public ICollection<Size> GetByCategoryId(long categoryId)
    {
        return _appDbContext.Sizes.Where(el => el.CategoryId == categoryId).ToList();
    }
    
    public Size GetById(long id)
    {
        return _appDbContext.Sizes.Single(el => el.Id == id); 
    }

    public ICollection<Size> GetSizeByUserId(long id)
    {
        return _appDbContext.Users.Where(user => user.Id == id)
               .Include(user => user.Sizes).ThenInclude(s => s.Category)
               .Single().Sizes .ToList();
    }

    public ICollection<Size> GetAll()
    {
        return _appDbContext.Sizes.ToList();
    }

    public Size Create(Size obj)
    {
        _appDbContext.Sizes.Add(obj);
        _appDbContext.SaveChanges(); 
        return obj;
    }

    public Size Update(Size obj)
    {
        _appDbContext.Sizes.Update(obj);
        _appDbContext.SaveChanges(); 
        return obj;
    }

    public void DeleteById(long id)
    {
        _appDbContext.Sizes.Remove(new Size(){Id = id});
        _appDbContext.SaveChanges();
    }
}