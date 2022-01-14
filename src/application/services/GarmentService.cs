using System.Linq;
using System.Security.Claims;
using application.DTOs;
using application.persistence;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;

namespace application.services;

public class GarmentService : IGarmentService

{
    private readonly IGarmentRepository _garmentRepository;
    private readonly UserManager<User> _userManager;
    private readonly IPropertyService _propertyService;
    private readonly IShapeRepository _shapeRepository;

    public GarmentService(IGarmentRepository garmentRepository, UserManager<User> userManager,
        IPropertyService propertyService, IShapeRepository shapeRepository)
    {
        _garmentRepository = garmentRepository;
        _userManager = userManager;
        _propertyService = propertyService;
        _shapeRepository = shapeRepository;
    }

    
    public async Task LikeOrDislikeGarment(ClaimsPrincipal userClaim, long garmentId)
    {
        var user = await _userManager.GetUserAsync(userClaim);
        var garment = _garmentRepository.GetById(garmentId);
        if (user.Garments.Contains(garment))
        {
            user.Garments.Remove(garment);
        }
        else
        {
            user.Garments.Add(garment);
        }
        
        var res = await _userManager.UpdateAsync(user);
        if (!res.Succeeded)
        {
            throw new Exception("internal server error");
        }
    }


    // TODO : match garment properties
    public async Task<ICollection<GarmentDto>> GetUserGarmentsByKeyword(ClaimsPrincipal userClaim, string searchKeyword, int pageNumber, int pageSize)
    {
        return (await GetUserGarments(userClaim, pageNumber, pageSize))
            .Where(garment =>
                garment.Category == searchKeyword
                || garment.Name == searchKeyword).ToList();
    }

    public async Task<ICollection<GarmentDto>> GetUserGarmentsByCategory(ClaimsPrincipal userClaim, long categoryId, int pageNumber, int pageSize)
    {
        return (await GetUserGarments(userClaim,pageNumber, pageSize))
            .Where(garment => garment.CategoryId == categoryId).ToList();
    }

    // TODO: move to repository 
    public async Task<ICollection<GarmentDto>> GetUserGarments(ClaimsPrincipal userClaim, int pageNumber, int pageSize)
    {
        var user = await _userManager.GetUserAsync(userClaim);
        if (user.ShapeId != null)
        {
            throw new Exception("you should enter the body sizes to get the appropriate garments for you");
        }
        
        var shape = _shapeRepository.GetById(user.ShapeId ?? 1);
        return _garmentRepository.GetAll()
            // .Where(garment => categoryId == 0 || (garment.CategoryId == categoryId))
            .Where(garment =>
                ((garment.Properties.Count(property => shape.Properties.Contains(property)) / garment.Properties.Count()) > 0.6))
            // true / false 
            .Where(garment =>
            {
                // TODO : fix runtime
                foreach (var garmentSize in garment.Sizes)
                {
                    foreach (var userSize in user.Sizes)
                    {
                        if (garmentSize.CategoryId == userSize.CategoryId &&
                            garmentSize.Id == userSize.Id)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }).Skip((pageNumber - 1) * pageSize)  
            .Take(pageSize)// TODO paging meta data
            .Select(garment => new GarmentDto()
            {
                Id = garment.Id,
                Brand = garment.Brand,
                Description = garment.Description,
                Name = garment.Name,
                Price = garment.Price,
                Category = garment.Category.Name,
                CreatedAt = garment.CreatedAt,
                StoreId = garment.StoreId,
                Colors = garment.Colors.Select(color => color.Name).ToList(),
                Images = garment.Images.Select(photo => photo.Path).ToList(),
                Sizes = garment.Sizes.Select(size => size.Name).ToList(),
                StoreDto = new StoreDto()
                {
                    Id = garment.Store.Id,
                    StoreName = garment.Store.Name,
                    
                    Locations = garment.Store.Locations.Select(l => new LocationDto()
                    {
                        City = l.City,
                        Country = l.Country,
                        Street = l.Street,
                        PhoneNumaber = l.PhoneNumaber
                    }).ToList(),
                    Rank = garment.Store.StoreFeedbacks.Sum(feedback => feedback.Rate) / garment.Store.StoreFeedbacks.Count
                }
            })
            .ToList();
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
            Images = garment.Images.Select(photo => photo.Path).ToList(),
            Sizes = garment.Sizes.Select(size => size.Name).ToList(),
            
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
            StoreId = garment.StoreId,
            StoreDto = new StoreDto
            {
                StoreName = garment.Store.Name,
                Locations = garment.Store.Locations.Select(l => new LocationDto
                {
                    Id = l.Id,
                    City = l.City,
                    Country = l.Country,
                    PhoneNumaber = l.PhoneNumaber,
                    Street = l.Street,

                }).ToList(),
            },
            Colors = garment.Colors.Select(color => color.Name).ToList(),
            Images = garment.Images.Select(photo => photo.Path).ToList(),
            Sizes = garment.Sizes.Select(size => size.Name).ToList()
        }).ToList();
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
            StoreId = obj.StoreId,
            Colors = obj.ColorsOfId.Select(colorId => new Color {Id = colorId}).ToList(),
            Images = obj.Images.Select(photo => new Image {Path = photo}).ToList(),
            Properties = obj.Properties.Select(property => new Property { Id = property }).ToList(),
            Sizes = obj.SizesOfId.Select(sizeId => new Size(){Id = sizeId}).ToList()
        });
         obj.Id = garment.Id;
         obj.CreatedAt = garment.CreatedAt;
        return obj ;
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
            StoreId = obj.StoreId,
            Colors = obj.ColorsOfId.Select(colorId => new Color { Id = colorId }).ToList(),
            Images = obj.Images.Select(photo => new Image { Path = photo }).ToList(),
            Properties = obj.Properties.Select(property => new Property { Id = property }).ToList(),
            Sizes = obj.SizesOfId.Select(sizeId => new Size() { Id = sizeId }).ToList()
        });
        obj.Id = garment.Id;
        obj.CreatedAt = garment.CreatedAt;
        return obj;
    }

    public ICollection<ColorDto> GetColors()
    {
        return _garmentRepository.GetColors().Select(color => new ColorDto
        {
            Id = color.Id,
            Name = color.Name,
        }).ToList();
    }

    public ICollection<SizeDto> GetSizeByCategory(long categoryId)
    {
        return _garmentRepository.GetSizeByCategory(categoryId).Select(size => new SizeDto
        {
            Id = size.Id,
            Name = size.Name,
            CM = size.CM,
            CategoryId = size.CategoryId,
        }).ToList();
    }
}