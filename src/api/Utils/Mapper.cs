using api.ApiDTOs;
using application.DTOs;

namespace api.Utils;

public class Mapper
{
    public static ICollection<GarmentApiDto> FromGarmentDtoToGarmentApiDto(ICollection<GarmentDto> garmentDtos)
    {
        return garmentDtos.Select(data => new GarmentApiDto()
        {
            Id = data.Id,
            Name = data.Name,
            Description = data.Description,
            Brand = data.Brand,
            Price = data.Price,
            CategoryId = data.CategoryId,
            Category = data.Category,
            StoreId = data.StoreId,
            Images = data.Images,
            Colors = data.Colors,
            Sizes = data.Sizes,
            IsLike = data.IsLike,
        }).ToList();
    }
}