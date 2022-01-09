using application.DTOs;
using application.persistence;
using domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public PropertyDto Create(PropertyDto obj)
        {
            var property = _propertyRepository.Create(new Property
            {
                Name = obj.Name,
                Description = obj.Description,
                GroupId = obj.GroupId,
                //Images = obj.Images.Select(photo => new Image
                //{
                //    Path = photo
                //}).ToList(),
            }) ;

            return new PropertyDto { 
              Id = property.Id,
              Description = property.Description != null ? property.Description : "",
              Name = property.Name,
              //CategoryId = property.CategoryId ,
              GroupId= property.GroupId == null ?0:0,
              //Images = property.Images.Select(photo => photo.Path).ToList(),
            };
        }

        public void DeleteById(long id)
        {
            _propertyRepository.DeleteById(id);
        }

        public PropertyDto Edit(PropertyDto obj)
        {
            var property = _propertyRepository.Update(new Property
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                //CategoryId = obj.CategoryId,
                GroupId = obj.GroupId,
                //Images = obj.Images.Select(photo => new Image
                //{
                //    Path = photo
                //}).ToList(),
            });

            return new PropertyDto
            {
                Id = property.Id,
                Description = property.Description,
                CreatedAt = property.CreatedAt,
                Name = property.Name,
                //Images = property.Images.Select(photo => photo.Path).ToList(),
                //CategoryId = property.CategoryId,
                GroupId = property.GroupId == null ?0:0,
            };
        }

        public ICollection<PropertyDto> GetAll()
        {
            var propertys = _propertyRepository.GetAll();

            return propertys.Select(property => new PropertyDto
            {
                Id = property.Id,
                Description = property.Description,
                //Category = property.Category.Name,
                Group = property.Group.Name,
                CreatedAt = property.CreatedAt,
                Name = property.Name,
                //CategoryId = (long)property.CategoryId,
                //Images = property.Images.Select(photo => photo.Path).ToList(),
            }).ToList();
        }

        public ICollection<PropertyDto> GetAllPropertyWithGroup()
        {
            //var data = _propertyRepository.GetAllPropertyWithGroup();
            // foreach(var item in data)
            //{
            //    foreach (var j in item.)
            //    {

            //    }
            //}
            return null;
        }

        public PropertyDto GetById(long id)
        {
            var property = _propertyRepository.GetById(id);

            return new PropertyDto
            {
                Id = property.Id,
                Description = property.Description,
                //Category = property.Category.Name,
                Group = property.Group.Name,
                CreatedAt = property.CreatedAt,
                Name = property.Name,
                Images = property.Images.Select(photo => photo.Path).ToList(),
            };
        }

        public ICollection<PropertyDto> GetPropertysByGroupId(long groupId)
        {
            var data = _propertyRepository.GetPropertysByGroupId(groupId)
                       .Select(p => new PropertyDto
                       {
                           Id = p.Id,
                           Name = p.Name,
                       }).ToList();
            return data;
        }

        // public ICollection<PropertyDto> GetPropertysByShape(Shape userShape)
        // {
        //     _propertyRepository.GetPropertysByShape(Shape userShape); 
        // }
    }
}
