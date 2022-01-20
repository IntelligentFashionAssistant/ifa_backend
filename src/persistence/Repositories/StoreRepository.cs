using System.Collections.Generic;
using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Propertys.Repositories;
    
public class StoreRepository : IStoreRepository
{
    
    private readonly AppDbContext _appDbContext;

    public StoreRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Store> GetById(long id)
    {
        return _appDbContext.Stores.Where(store => store.Id == id)
                .Include(store => store.User)
                .Include(store => store.StoreFeedbacks).ThenInclude(f => f.User)
                .Include(store => store.Locations)
                .AsNoTracking()
                .Single();
    }
    public async Task<long> GetByUserId(long userId)
    {
        return _appDbContext.Stores.AsNoTracking().Single(store => store.UserId == userId).Id;
    }

    public async Task<ICollection<Store>> GetAll()
    {
        return _appDbContext.Stores.Where(store => store.IsApprove == true)
                .Include(store => store.User)
                .Include(store => store.StoreFeedbacks).ThenInclude(f => f.User)
                .AsNoTracking().ToList();
    }
    public async Task<ICollection<Store>> GetAllNotApproved()
    {
        return _appDbContext.Stores.Where(store => store.IsApprove == false)
                .Include(store => store.User)
                .Include(store => store.StoreFeedbacks).ThenInclude(f => f.User)
                .AsNoTracking().ToList();
    }

    public async Task<Store> Create(Store obj)
    {
        _appDbContext.Stores.Add(obj);
        _appDbContext.SaveChanges();
        return obj; 
    }

    public async Task<Store> Update(Store obj)
    {
        var stroe = _appDbContext.Stores.Single(s => s.Id == obj.Id);

        stroe.Name = obj.Name;
        _appDbContext.SaveChanges();
        return obj;
    }

    public async Task DeleteById(long id)
    {
        var obj = _appDbContext.Stores.Single(store => store.Id == id);
        _appDbContext.Stores.Remove(obj);
        _appDbContext.SaveChanges();
    }

    public ICollection<Garment> GetGarmentsByCategory(long categoryId, long storeId)
    {
        var garments = _appDbContext.Garments
                      .Where(g => g.CategoryId == categoryId && g.StoreId == storeId)
                      .Include(g => g.Images)
                      .Include(g => g.Properties)
                      .Include(g => g.Sizes)
                      .Include(g => g.Colors)
                      .AsNoTracking()
                      .ToList();
        return garments;
        }
    
    public bool Approved(long storeId)
    {
        var store = _appDbContext.Stores.Single(store => store.Id == storeId);
        if (store == null)
            return false;

        store.IsApprove = true;
        _appDbContext.SaveChanges();

        return true;
    }

    //public bool Cancel(long storeId)
    //{
    //    var store = _appDbContext.Stores.Single(store => store.Id == storeId);
    //    if (store == null)
    //        return false;

    //    store.IsApprove = false;
    //    _appDbContext.SaveChanges();

    //    return true;
    //}

    public async Task<string>  AddPhoto(string photo , long storeId)
    {
        var store =  _appDbContext.Stores.Single(store => store.Id == storeId);

         store.PhotoStore = photo;
        _appDbContext.SaveChanges();

        return photo;
    }

    public async Task<Store> Profile(long storeId) 
    {
        return _appDbContext.Stores.Where(store => store.Id == storeId)
                                   .Include(store => store.User)
                                   .Include(store => store.Locations).Single(); 
    }
}