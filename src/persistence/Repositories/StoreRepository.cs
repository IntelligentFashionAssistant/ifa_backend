using System.Collections.Generic;
using application.persistence;
using domain.Entitys;

namespace persistence.Repositories;
    
public class StoreRepository : IStoreRepository
{
    
    private readonly AppDbContext _appDbContext;

    public StoreRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public Store GetById(long id)
    {
        return _appDbContext.Stores.Single(store => store.Id == id);
    }

    public ICollection<Store> GetAll()
    {
        return _appDbContext.Stores.ToList();
    }

    public Store Create(Store obj)
    {
        _appDbContext.Stores.Add(obj);
        _appDbContext.SaveChanges();
        return obj; 
    }

    public Store Update(Store obj)
    {
        _appDbContext.Update(obj);
        _appDbContext.SaveChanges();
        return obj;
    }

    public void DeleteById(long id)
    {
        var obj = _appDbContext.Stores.Single(store => store.Id == id);
        _appDbContext.Stores.Remove(obj);
        _appDbContext.SaveChanges();
    }
}