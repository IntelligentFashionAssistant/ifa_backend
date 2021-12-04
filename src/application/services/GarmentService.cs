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
    public class GarmentService : IGarmentService

    {
        private readonly IGarmentRepository _garmentRepository;

        public GarmentService(IGarmentRepository garmentRepository)
        {
            _garmentRepository = garmentRepository;
        }

        public GarmentDto Create(GarmentDto obj)
        {
            //TODO Properties of list int or propertieDto and insert to shape_garment table

            var garment = _garmentRepository.Create(new Garment
            {
                Brand = obj.Brand,
                CategoryId = obj.CategoryId,
                Description = obj.Description,
                Name = obj.Name,
                Price = obj.Price,
                //StoreId = obj.StoreId,
                Colors = obj.Colors.Select(color => new Color { Name = color }).ToList(),
                Images = obj.Images.Select(photo => new Image { Path = photo }).ToList(),
                // TODO : IDs 
                Properties = obj.Properties.Select(property => new Property
                {
                    Id = property.Id,
                    Name = property.Name,
                    Description = property.Description,
                    GroupId = property.GroupId,
                }).ToList(),
            }) ;

            return new GarmentDto {
                Id = garment.Id,
                Brand = garment.Brand,
                Description = garment.Description,
                Name = garment.Name,
                Price = garment.Price,
                Category = garment.Category.Name,
                CreatedAt = garment.CreatedAt,
                Colors = garment.Colors.Select(color => color.Name).ToList(),
                Images = garment.Images.Select(photo => photo.Path).ToList(),

              };
        }

        public void DeleteById(long id)
        {
            _garmentRepository.DeleteById(id);
        }


        public GarmentDto Edit(GarmentDto obj)
        {
            var garment = _garmentRepository.Update(new Garment
            {
                Id = obj.Id,
                Brand = obj.Brand,
                CategoryId = obj.CategoryId,
                Description = obj.Description,
                Name = obj.Name,
                Price = obj.Price,
                //StoreId = obj.StoreId,
                Colors = obj.Colors.Select(color => new Color { Name = color }).ToList(),
                Images = obj.Images.Select(photo => new Image { Path = photo }).ToList(),
                Properties = obj.Properties.Select(property => new Property
                {
                    Name = property.Name,
                    Description = property.Description,
                    GroupId = property.GroupId,
                }).ToList(),
            });

            return new GarmentDto
            {
                Id = garment.Id,
                Brand = garment.Brand,
                Description = garment.Description,
                Name = garment.Name,
                Price = garment.Price,
                Category = garment.Category.Name,
                CreatedAt = garment.CreatedAt,
                Colors = garment.Colors.Select(color => color.Name).ToList(),
                Images = garment.Images.Select(photo => photo.Path).ToList()
            };
        }

        public ICollection<GarmentDto> GetAll()
        {
            var garments = _garmentRepository.GetAll();

            return garments.Select(garment => new GarmentDto
            {
                Id = garment.Id,
                Brand = garment.Brand,
                Description = garment.Description,
                Name = garment.Name,
                Price = garment.Price,
                Category = garment.Category.Name,
                CreatedAt = garment.CreatedAt,
                Colors = garment.Colors.Select(color => color.Name).ToList(),
                Images = garment.Images.Select(photo => photo.Path).ToList()
            }).ToList();
        }

        public GarmentDto GetById(long id)
        {
            var garment = _garmentRepository.GetById(id);

            return new GarmentDto
            {
                Id = garment.Id,
                Brand = garment.Brand,
                Description = garment.Description,
                Name = garment.Name,
                Price = garment.Price,
                Category = garment.Category.Name,
                CreatedAt = garment.CreatedAt,
                Colors = garment.Colors.Select(color => color.Name).ToList(),
                Images = garment.Images.Select(photo => photo.Path).ToList()
            };
        }

    }
}
