using System.Collections.Generic;
using application.DTOs;

namespace application.services
{
    public interface IPropertyService : IService<PropertyDto, long>
    {
        ICollection<PropertyDto> GetAllPropertyWithGroup();
    }
}