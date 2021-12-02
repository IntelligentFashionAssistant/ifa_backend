using System.Collections.Generic;
using System.Linq;
using domain.Entitys;

namespace application.persistence
{
    public interface IPropertyRepository : IRepository<Property, long>
    {
        IDictionary<string, ICollection<Property>> GetAllPropertyWithGroup();
    }
}