using System.Collections.Generic;

namespace application.persistence
{
    public interface IRepository<TEntity, TEntityId>
    {
        TEntity GetById(TEntityId id);
        ICollection<TEntity> GetAll();
        TEntity Create(TEntity obj);
        TEntity Update(TEntity obj);
        
    }
}