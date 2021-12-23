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

        //Methods
        public async Task<UserDto> GetUserById(long id)
        {
            var user = await _userManager.FindByIdAsync((id).ToString());
                 if(user != null)
            {
                return new UserDto
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
                HouseNumber = obj.HouseNumber,
                PhoneNumber = obj.PhoneNumber,
                
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
                foreach (var e in result.Errors)
                {
                    error += e.Description + ",";
                }
                // var mm = result.Errors.Select(e => e.Description);

                throw new NullReferenceException(error);
            }
        }
        public async Task<UserDto> EditUser(UserDto obj)
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
        public async Task DeleteUserById(long id)
        {
            var user = await _userManager.FindByIdAsync((id).ToString());
            if (user != null)
            {
              var result =  _userManager.DeleteAsync(user);
            }
            else
            {
                throw new NullReferenceException("User not found");
            }
        }
        public ICollection<UserDto> SearchUser(UserDto searchObj)
        {
            throw new System.NotImplementedException();
        }

        //TODO
        public UserDto Create(UserDto obj)
        {
            throw new NotImplementedException();
        }
        public UserDto Edit(UserDto obj)
        {
            throw new System.NotImplementedException();
        }
        public UserDto GetById(long id)
        {
            throw new NotImplementedException();
        }
        void IService<UserDto, long>.DeleteById(long id)
        {
            throw new NotImplementedException();
        }
    }
}