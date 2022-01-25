using System.Collections.Generic;
using System.Security.Claims;
using api.ApiDTOs;
using application.DTOs;
using application.exceptions;
using application.persistence;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace application.services
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<User> _userManager;
        private readonly IShapeRepository _shapeRepository;
        private readonly IBodySizesRepository _bodySizesRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly ICategoryRepository _categoryRepository;

     public CustomerService(UserManager<User> userManager, IShapeRepository shapeRepository, IBodySizesRepository bodySizesRepository, ISizeRepository sizeRepository, ICategoryRepository categoryRepository)
        {
            _userManager = userManager;
            _shapeRepository = shapeRepository;
            _bodySizesRepository = bodySizesRepository;
            _sizeRepository = sizeRepository;
            _categoryRepository = categoryRepository;
        }
        
        
    public async Task<CustomerDto> CalculateBodyShape(ClaimsPrincipal userClaim, BodySizesDto bodySizesDto)
        {
            var  user = await _userManager.GetUserAsync(userClaim);
            var bodySize = new BodySize() ;
            var calculatedBodyShape = _calculateBodyShape(bodySizesDto);
            if (calculatedBodyShape == null)
            {
                throw new ArgumentException("the enterd sizes are not valid");
            }
            // calculate user sizes 
            user.Sizes = _calculateUserSizes(bodySizesDto);
            // save entered body sizes
            if(bodySizesDto.Id == 0)
            {

            bodySize = _bodySizesRepository.Create(new BodySize
            {
                Id  = bodySizesDto.Id,
                BustSize = bodySizesDto.BustSize,
               ShoulderSize = bodySizesDto.ShoulderSize,
               HipSize = bodySizesDto.HipSize,
               WaistSize = bodySizesDto.WaistSize,
            });
            }
            else
            {
             bodySize = _bodySizesRepository.Update(new BodySize
             {
                 Id = bodySizesDto.Id,
                 BustSize = bodySizesDto.BustSize,
                 ShoulderSize = bodySizesDto.ShoulderSize,
                 HipSize = bodySizesDto.HipSize,
                 WaistSize = bodySizesDto.WaistSize,
             });
            }
            user.BodySizeId = bodySize.Id;
            user.ShapeId = calculatedBodyShape.Id;
            var res = await _userManager.UpdateAsync(user);
            if (res.Succeeded)
            {
                var updatedUser = await _userManager.GetUserAsync(userClaim);
                return new CustomerDto()
                {
                    Id = user.Id,
                    FirstName = updatedUser.FirstName,
                    LastName = updatedUser.LastName,
                    PhoneNumber = updatedUser.PhoneNumber,
                    BirthDate = updatedUser.BirthDate,
                    City = updatedUser.City,
                    Country = updatedUser.Country,
                    Email = updatedUser.Email,
                    HouseNumber = updatedUser.HouseNumber,
                    Street = updatedUser.Street,
                    Username = updatedUser.UserName,
                    BustSize = user.BodySize.BustSize,
                    HipSize = user.BodySize.HipSize,
                    WaistSize = user.BodySize.WaistSize,
                    ShoulderSize = user.BodySize.ShoulderSize,
                    Shape = updatedUser.Shape?.Name
                };
            }
            else
            {
                throw new CustomException(
                    "Entered body Sizes are not valid", 
                    res.Errors.Select(error => error.Description).ToList());
            } }


    private ICollection<Size> _calculateUserSizes(BodySizesDto bodySizes)
    {
        var categories = _categoryRepository.GetAll();
        var sizes = new List<Size>();

        
        var topCategories = new List<string>() { "Jumpsuit", "Top", "Dress" };
        var bottomCategories = new List<string>() { "Pants", "Skirt" };
        foreach (var category in categories) 
        {
           
            if (topCategories.Contains(category.Name))
            {
                sizes.Add(_sizeRepository.GetByCategoryId(category.Id).Where(s => Math.Abs(s.CM - bodySizes.BustSize) < 20).FirstOrDefault());
            }
            else
            {
                sizes.Add(_sizeRepository.GetByCategoryId(category.Id).Where(s => Math.Abs(s.CM - bodySizes.WaistSize) < 20).FirstOrDefault());
            }
        }

        return sizes;
    }
          
        /// <summary>
        /// Hourglass
        /// If (bust - hips) ≤ 1" AND (hips - bust) < 3.6" AND (bust - waist) ≥ 9" OR (hips - waist) ≥ 10"
        /// Bottom hourglass
        /// If (hips - bust) ≥ 3.6" AND (hips - bust) < 10" AND (hips - waist) ≥ 9" AND (high hip/waist) < 1.193
        /// Top hourglass
        /// If (bust - hips) > 1" AND (bust - hips) < 10" AND (bust - waist) ≥ 9"
        /// Spoon
        /// If (hips - bust) > 2" AND (hips - waist) ≥ 7" AND (high hip/waist) ≥ 1.193
        /// Triangle
        /// If (hips - bust) ≥ 3.6" AND (hips - waist) < 9"
        /// Inverted triangle
        /// If (bust - hips) ≥ 3.6" AND (bust - waist) < 9"
        /// Rectangle
        /// If (hips - bust) < 3.6" AND (bust - hips) < 3.6" AND (bust - waist) < 9" AND (hips - waist) < 10"
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        /// 
       

        private Shape _calculateBodyShape(BodySizesDto b)
        {   Shape shape = null; 
            if (((b.BustSize - b.HipSize) <= 2.5) && ((b.HipSize - b.BustSize) < 9.14) &&
                ((b.BustSize - b.WaistSize) >= 22.9) || ((b.HipSize - b.WaistSize) >= 25.4))
            {
                shape = _shapeRepository.GetShapeByName("HourGlass");
            } 
            else if (((b.HipSize - b.BustSize) > 9.14) && ((b.HipSize - b.WaistSize) < 22.9))
            {
                shape = _shapeRepository.GetShapeByName("Apple");
            }
            else if (((b.HipSize - b.BustSize) >= 9.14) && ((b.HipSize - b.WaistSize) > 22.9))
            {
                shape = _shapeRepository.GetShapeByName("Triangle");
            }
            else if (((b.BustSize - b.HipSize) >= 9.14) && ((b.BustSize - b.WaistSize) > 22.9))
            {
                shape = _shapeRepository.GetShapeByName("Inverted triangle");
            }
            else if (((b.HipSize - b.BustSize) < 9.14) && ((b.BustSize - b.HipSize) < 9.14) &&
                     ((b.BustSize - b.WaistSize) < 22.9) && ((b.HipSize / b.WaistSize) < 25.4))
            {
                shape = _shapeRepository.GetShapeByName("Rectangle");
            }
            else
            {
                return null; 
            }
            return shape;
        }
        public async Task<CustomerDto> GetById(long id)
        {
            var user = await _userManager.FindByIdAsync((id).ToString());
                 if(user != null)
            {
                return new CustomerDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    BirthDate = user.BirthDate,
                    City = user.City,
                    Country = user.Country,
                    Email = user.Email,
                    HouseNumber = user.HouseNumber,
                    Street = user.Street,
                    Username = user.UserName,

                };
            }
            else
            {
                throw new NotImplementedException("User not found");
            }
          
        }
        public async Task<ICollection<CustomerDto>> GetAll()
        {
            var users = await _userManager.GetUsersInRoleAsync("Customer");
            return users.Select(user => new CustomerDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    City = user.City,
                    Country = user.Country,
                    Email = user.Email,
                    Street = user.Street,
                    Username = user.UserName,
                }
            ).ToList();
        }
        public async Task<CustomerDto> Create(CustomerDto obj)
        {
            var user = new User()
            {
                Email = obj.Email,
                City = obj.City,
                BirthDate = obj.BirthDate,
                UserName = obj.Username,
                
            };
            var result = await _userManager.CreateAsync(user, obj.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                obj.Id = user.Id;
                return obj;
            }
            else
            {
                string error = " ";
                foreach (var e in result.Errors)
                {
                    error += e.Description + ",";
                }
                // var mm = result.Errors.Select(e => e.Description);

                throw new NullReferenceException(error);
            }
        }
        public async Task<CustomerDto> Edit(CustomerDto obj)
        {
            var user = await _userManager.FindByIdAsync((obj.Id).ToString());

            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.BirthDate = obj.BirthDate;
            user.Country = obj.Country;
            user.City = obj.City;
            user.Street = obj.Street;
            user.PhoneNumber = obj.PhoneNumber;
            user.UserName = obj.Username;
            user.HouseNumber = obj.HouseNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new CustomerDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    City = user.City,
                    Country = user.Country,
                    Email = user.Email,
                    Street = user.Street,
                    Username = user.UserName,
                    HouseNumber = user.HouseNumber,
                    PhoneNumber = obj.PhoneNumber,
                };
            }
            else
            {
                string error = " ";
                foreach (var e in result.Errors)
                {
                    error += e.Description + ",";
                }

                throw new NullReferenceException(error);
            }


        }
        public async Task DeleteById(long id)
        {
            var user = await _userManager.FindByIdAsync((id).ToString());
            if (user != null)
            {
              var result = await _userManager.DeleteAsync(user);
            }
            else
            {
                throw new NullReferenceException("User not found");
            }
        }

        public async Task<CustomerDto> Profile(ClaimsPrincipal userClaim)
        {
            var user = await _userManager.GetUserAsync(userClaim);

            if (user == null)
                throw new Exception("user not found");

            var bodySize =  _bodySizesRepository.GetById(user.BodySizeId ?? 0);
            var shape = _shapeRepository.GetById(user.ShapeId ?? 0);
            var userSizes = _sizeRepository.GetSizeByUserId(user.Id);
            return new CustomerDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Photo = user.Phtot,
                Country = user.Country,
                BirthDate = user.BirthDate,
                City = user.City,
                Street = user.Street,
                Shape = shape.Name,
                BustSize = bodySize.BustSize,
                HipSize = bodySize.HipSize,
                ShoulderSize = bodySize.ShoulderSize,
                WaistSize = bodySize.WaistSize,
                Username = user.UserName,
                Sizes = userSizes.ToDictionary(x => x.Category.Name, x => x.Name),
            };
             
            
     }

        public async Task<string> AddPhoto(string photo, ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            user.Phtot = photo;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return photo;
            }
            else
            {
                string error = " ";
                foreach (var e in result.Errors)
                {
                    error += e.Description + ",";
                }

                throw new NullReferenceException(error);
            }
           
        }

    }
}