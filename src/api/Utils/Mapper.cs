using api.ApiDTOs;
using application.DTOs;

namespace api.Utils;

public class Mapper
{
    public static ICollection<GarmentApiDto> FromGarmentDtoToGarmentApiDto(ICollection<GarmentDto> garmentDtos)
    {
        return garmentDtos.Select(data => new GarmentApiDto()
        {
            Name = data.Name,
            Description = data.Description,
            Brand = data.Brand,
            Price = data.Price,
            CategoryId = data.CategoryId,
            StoreId = data.StoreId,
            Images = data.Images,
            Colors = data.Colors,
            Sizes = data.Sizes,
            StoreApiDto = new StoreApiDto()
            {
                Id = data.StoreDto.Id,
                StoreName = data.StoreDto.StoreName,
                PhoneNumber = data.StoreDto.PhoneNumber,
                Locations = data.StoreDto.Locations.Select(l => new LocationApiDto()
                {
                    City = l.City,
                    Country = l.Country,
                    Street = l.Street,
                }).ToList()
            }
        }).ToList();
    }
}