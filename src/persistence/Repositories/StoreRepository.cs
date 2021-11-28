using System.Collections.Generic;
using application.persistence;
using domain.Entitys;

namespace repository.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        public Store GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Store> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Store Create(Store obj)
        {
            throw new System.NotImplementedException();
        }

        public Store Update(Store obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}