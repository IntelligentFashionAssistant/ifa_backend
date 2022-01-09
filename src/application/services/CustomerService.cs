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
    // UserServices uses UserManager from Identity Framework 
    // this is why there is no UserRepository
    // TODO : implement ICustomerService
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
            var bodySizes = new BodySizes()
            {
                 BustSize = bodySizesDto.BustSize,
                 HipSize = bodySizesDto.HipSize,
                 ShoulderSize =bodySizesDto.ShoulderSize, 
                  WaistSize = bodySizesDto.WaistSize, 
            };

            // calculate body shape based on entered body Sizes 
            // and throw an exception if the entered sizes are not valid
            var calculatedBodyShape = _calculateBodyShape(bodySizes);
            if (calculatedBodyShape == null)
            {
                throw new ArgumentException("the enterd sizes are not valid");
            }
            
            // calculate user sizes 
            user.Sizes = _calculateUserSizes(bodySizes);
            // save entered body sizes
            bodySizes = _bodySizesRepository.Create(bodySizes); 
            user.BodySizesId = bodySizes.Id;
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
                    BustSize = user.BodySizes.BustSize,
                    HipSize = user.BodySizes.HipSize,
                    WaistSize = user.BodySizes.WaistSize,
                    ShoulderSize = user.BodySizes.ShoulderSize,
                    Shape = updatedUser.Shape?.Name
                };
            }
            else
            {
                throw new CustomException(
                    "Entered body Sizes are not valid", 
                    res.Errors.Select(error => error.Description).ToList());
            }
            
        }


    private ICollection<Size> _calculateUserSizes(BodySizes bodySizes)
    {
        var categories = _categoryRepository.GetAll();
        var sizes = new List<Size>();

        
        // TODO : check category names 
        var topCategories = new List<string>() {"tshirt", "top", "dress"};
        var bottomCategories = new List<string>() {"pants", "skirt"};
        foreach (var category in categories) // pants, tops, dress
        {
            // pants : 32 34  => 32
            // tops : M L XL => M
            if (topCategories.Contains(category.Name.ToLower()))
            {
                sizes.Add(_sizeRepository.GetByCategoryId(category.Id).Single(s => Math.Abs(s.CM - bodySizes.BustSize) < 2));
            }
            else
            {
                sizes.Add(_sizeRepository.GetByCategoryId(category.Id).Single(s => Math.Abs(s.CM - bodySizes.WaistSize) < 2));
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
        private Shape _calculateBodyShape(BodySizes b)
        {
            // TODO : return the correct shape
            Shape shape = null; 
            if (((b.BustSize - b.HipSize) <= 1) && ((b.HipSize - b.BustSize) < 3.6) &&
                ((b.BustSize - b.WaistSize) >= 9) || ((b.HipSize - b.WaistSize) >= 10))
            {
                shape = _shapeRepository.GetShapeByName("HourGlass");
            }
            else if (((b.HipSize - b.BustSize) >= 3.6) && ((b.HipSize - b.BustSize) < 10) &&
                     ((b.HipSize - b.WaistSize) >= 9) && ((b.HipSize / b.WaistSize) < 1.193))
            {
                shape = _shapeRepository.GetShapeByName("HourGlass");
            }
            else if (((b.BustSize - b.HipSize) > 1) && ((b.BustSize - b.HipSize) < 10) &&
                     ((b.BustSize - b.WaistSize) >= 9))
            {
                shape = _shapeRepository.GetShapeByName("HourGlass");
                
            }
            else if (((b.HipSize - b.BustSize) > 2) && ((b.HipSize - b.WaistSize) >= 7) &&
                     ((b.HipSize - b.WaistSize) >= 1.193))
            {
                shape = _shapeRepository.GetShapeByName("HourGlass");
            }
            else if (((b.HipSize - b.BustSize) >= 3.6) && ((b.HipSize - b.WaistSize) > 9))
            {
                shape = _shapeRepository.GetShapeByName("HourGlass");
            }
            else if (((b.BustSize - b.HipSize) >= 3.6) && ((b.BustSize - b.WaistSize) > 9))
            {
                shape = _shapeRepository.GetShapeByName("HourGlass");
            }
            else if (((b.HipSize - b.BustSize) < 3.6) && ((b.BustSize - b.HipSize) < 3.6) &&
                     ((b.BustSize - b.WaistSize) < 9) && ((b.HipSize / b.WaistSize) < 10))
            {
                shape = _shapeRepository.GetShapeByName("HourGlass");
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
            var users = await _userManager.Users.ToListAsync();
            return users.Select(user => new CustomerDto
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

                }
            ).ToList();
        }
        public async Task<CustomerDto> Create(CustomerDto obj)
        {
            var user = new User()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                Country = obj.Country,
                City = obj.City,
                BirthDate = obj.BirthDate,
                Street = obj.Street,
                UserName = obj.Username,
                HouseNumber = obj.HouseNumber,
                PhoneNumber = obj.PhoneNumber,
                
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

    }
}