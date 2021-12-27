using application.DTOs;
using application.persistence;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services
{
    public class StoreService : IStoreService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILocationRepository _locationRepository;
        private readonly IStoreRepository _storeRepository;
        public StoreService(UserManager<User> userManager,
                            ILocationRepository locationRepository,
                            IStoreRepository storeRepository)
        {
            _userManager = userManager;
            _locationRepository = locationRepository;
            _storeRepository = storeRepository;
        }
        public async Task<StoreDto> Create(StoreDto obj)
        {
            var user = new User()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Email = obj.Email,
                BirthDate = obj.BirthDate,
                UserName = obj.Username,
                PhoneNumber = obj.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, obj.Password);

            if (result.Succeeded)
            {
                var store = await _storeRepository.Create(new Store
                {
                    Name = obj.StoreName,
                    UserId = user.Id,
                    // Locations = new List<Location> {
                    //     new Location { 
                    //         Country = obj.Country,
                    //         City = obj.City,
                    //         Street = obj.Street,

                    //     } 
                    //} 
                });
                var locatin = _locationRepository.Create(new Location
                {
                    Country = obj.Country,
                    City = obj.City,
                    Street = obj.Street
                });
                return new StoreDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    City = locatin.City,
                    Country = locatin.Country,
                    Email = user.Email,
                    Street = locatin.Street,
                    Username = user.UserName,
                    StoreName = store.Name,
                    PhoneNumber = user.PhoneNumber,
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

        public async Task<StoreDto> Edit(StoreDto obj)
        {

            var user = new User()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                BirthDate = obj.BirthDate,
                UserName = obj.Username,
                PhoneNumber = obj.PhoneNumber,
            };
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var store = _storeRepository.GetByUserId(user.Id);
                var newStore = await _storeRepository.Update(new Store
                {
                    Id = store.Id,
                    Name = obj.StoreName,
                    UserId = user.Id,
                });
                return new StoreDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Username = user.UserName,
                    StoreName = newStore.Name,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
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

        public async Task<ICollection<StoreDto>> GetAll()
        {
            var data = await _storeRepository.GetAll();

            return  data.Select(l => new StoreDto
            {
                Id=l.Id,
                StoreName = l.Name,
                FirstName = l.User.FirstName,
                LastName = l.User.LastName,
                BirthDate= l.User.BirthDate,
                Email = l.User.Email,
                PhoneNumber = l.User.PhoneNumber,
                Username = l.User.UserName,
                CreatedAt = l.CreatedAt
            }).ToList();
        }

        public async Task<StoreDto> GetById(long id)
        {
           var data = await _storeRepository.GetById(id);

            return new StoreDto
            {
                Id = data.Id,
                StoreName = data.Name,
                FirstName = data.User.FirstName,
                LastName = data.User.LastName,
                Email = data.User.Email,
                PhoneNumber = data.User.PhoneNumber,
                Username = data.User.UserName,
                BirthDate = data.User.BirthDate,
                Locations = data.Locations.Select(l => new LocationDto
                {
                    Id = l.Id,
                    Country = l.Country,
                    City = l.City,
                    Street = l.Street,
                }).ToList(),
                CreatedAt = data.CreatedAt
            };
        }
      
    }
}
