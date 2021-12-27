using System.Collections.Generic;
using application.persistence;
using domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace persistence.Repositories;
    
public class StoreRepository : IStoreRepository
{
    
    private readonly AppDbContext _appDbContext;

    public StoreRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<Store> GetById(long id)
    {
        return  _appDbContext.Stores.Where(store => store.Id == id).Include(store => store.User).Single();
    }
    public async Task<Store> GetByUserId(long userId)
    {
        return _appDbContext.Stores.Single(store => store.UserId == userId);
    }

    public async Task<ICollection<Store>> GetAll()
    {
        return _appDbContext.Stores.Include(store => store.User).ToList();
    }

    public async Task<Store> Create(Store obj)
    {
        _appDbContext.Stores.Add(obj);
        _appDbContext.SaveChanges();
        return obj; 
    }

    public async Task<Store> Update(Store obj)
    {
        _appDbContext.Update(obj);
        _appDbContext.SaveChanges();
        return obj;
    }

    public async Task DeleteById(long id)
    {
        var obj = _appDbContext.Stores.Single(store => store.Id == id);
        _appDbContext.Stores.Remove(obj);
        _appDbContext.SaveChanges();
    }

   
}