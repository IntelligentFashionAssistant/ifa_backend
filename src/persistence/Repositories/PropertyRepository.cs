using System.Collections.Generic;
using application.persistence;
using domain.Entitys;

namespace repository.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        public Property GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Property> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Property Create(Property obj)
        {
            throw new System.NotImplementedException();
        }

        public Property Update(Property obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}