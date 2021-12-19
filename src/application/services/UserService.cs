using System.Collections.Generic;
using application.DTOs;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;

namespace application.services
{
    // UserServices uses UserManager from Identity Framework 
    // this is why there is no UserRepository
    public class UserService : IUserService
    {  
        private UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public UserDto GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<UserDto> GetAll()
        {
            throw new System.NotImplementedException("kenan kenan");
        }

        public async Task<UserDto> CreateUser(UserDto obj)
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
                HouseNumber = obj.HouseNumber
            };
            var result = await _userManager.CreateAsync(user, obj.Password);

            if (result.Succeeded)
            {
                return new UserDto
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
                    HouseNumber = user.HouseNumber
                };
            }
            else
            {
                string error = " ";
                foreach(var e in result.Errors)
                {
                    error += e.Description + ",";
                }
               // var mm = result.Errors.Select(e => e.Description);

                throw new NullReferenceException(error);
            }
        }

        public UserDto Edit(UserDto obj)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<UserDto> SearchUser(UserDto searchObj)
        {
            throw new System.NotImplementedException();
        }

        public UserDto Create(UserDto obj)
        {
            throw new NotImplementedException();
        }
    }
}