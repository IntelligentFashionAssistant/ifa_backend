using System.Collections.Generic;
using application.DTOs;
using domain.Entitys;

namespace application.services
{
    public interface IPropertyService : IService<PropertyDto, long>
    {
        ICollection<PropertyDto> GetAllPropertyWithGroup();
        ICollection<PropertyDto> GetPropertysByGroupId(long groupId);
        // ICollection<PropertyDto> GetPropertysByShape(Shape userShape);
    }
}