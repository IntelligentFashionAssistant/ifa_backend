using application.persistence;
using domain.Entitys;
using Propertys;

namespace repository.Repositories;

public class StoreFeedbackRepository : IStoreFeedbackRepository
{
    private readonly AppDbContext _appDbContext;

    public StoreFeedbackRepository(AppDbContext _appDbContext)
    {
        this._appDbContext = _appDbContext;
    }
    
    public StoreFeedback GetById(long id)
    {
        throw new NotImplementedException();
    }

    public ICollection<StoreFeedback> GetAll()
    {
        return _appDbContext.StoreFeedbacks.ToList();
    }

    public StoreFeedback Create(StoreFeedback obj)
    {
        _appDbContext.StoreFeedbacks.Add(obj);
        _appDbContext.SaveChanges();
        return obj;
    }

    public StoreFeedback Update(StoreFeedback obj)
    {
        _appDbContext.Update(obj);
        _appDbContext.SaveChanges();
        return obj;
    }

    public void DeleteById(long id)
    {
        _appDbContext.Remove(new StoreFeedback() {Id = id});
        _appDbContext.SaveChanges();
    }
}