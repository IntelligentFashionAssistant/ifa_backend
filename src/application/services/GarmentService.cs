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


    public async Task<ICollection<GarmentDto>> GetUserGarments(ClaimsPrincipal userClaim)
    {
        return await GetUserGarments(userClaim, 0);
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

    public async Task<ICollection<GarmentDto>> GetUserGarments(ClaimsPrincipal userClaim, long categoryId)
    {
        var user = await _userManager.GetUserAsync(userClaim);
        if (user.ShapeId != null)
        {
            throw new Exception("you should enter the body sizes to get the appropriate garments for you");
        }
        
        var shape = _shapeRepository.GetById(user.ShapeId ?? 1);
        return _garmentRepository.GetAll()
            .Where(garment =>  categoryId == 0 || (garment.CategoryId == categoryId))
            .Where(garment => ( (garment.Properties.Count(property => shape.Properties.Contains(property)) / garment.Properties.Count()) > 0.6) )
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
            })
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
                Sizes = garment.Sizes.Select(size => size.Name).ToList()
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
            Sizes = garment.Sizes.Select(size => size.Name).ToList()
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
            Colors = obj.Colors.Select(color => new Color {Name = color}).ToList(),
            Images = obj.Images.Select(photo => new Image {Path = photo}).ToList(),
            Properties = obj.Properties.Select(property => new Property { Id = property }).ToList(),
            Sizes = obj.Sizes.Select(size => new Size(){Name = size }).ToList()
        });

        return new GarmentDto
        {
            Id = garment.Id,
            Brand = garment.Brand,
            Description = garment.Description,
            Name = garment.Name,
            Price = garment.Price,
            CategoryId = garment.CategoryId,
            CreatedAt = garment.CreatedAt,
            Colors = garment.Colors.Select(color => color.Name).ToList(),
            Images = garment.Images.Select(photo => photo.Path).ToList(),
            Sizes = garment.Sizes.Select(size => size.Name).ToList(),
            StoreId = garment.StoreId,
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
            Colors = obj.Colors.Select(color => new Color {Name = color}).ToList(),
            Images = obj.Images.Select(photo => new Image {Path = photo}).ToList(),
            Properties = obj.Properties.Select(property => new Property {Id = property}).ToList(),
            Sizes = obj.Sizes.Select(size => new Size(){Name = size }).ToList()
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
            Images = garment.Images.Select(photo => photo.Path).ToList(),
            Sizes = garment.Sizes.Select(size => size.Name).ToList(),
        };
    }
}