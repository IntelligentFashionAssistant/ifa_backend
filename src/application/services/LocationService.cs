using application.persistence;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace application.services
{
    public class LocationService : ILocationService
    {
         private readonly ILocationRepository _locationRepository;
         private readonly UserManager<User> _userManager;
         private readonly IStoreRepository _storeRepository;
        
        public LocationService(ILocationRepository locationRepository,
                               UserManager<User> userManager,
                                IStoreRepository storeRepository)
        {
            _locationRepository = locationRepository;
            _userManager = userManager;
            _storeRepository = storeRepository;
        }


        public async Task<LocationDto> CreateLocation(LocationDto obj, ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            var storeId = await _storeRepository.GetByUserId(user.Id);
             obj.StoreId = storeId;
             return await Create(obj);
        }
        public async Task<LocationDto> EditLocation(LocationDto obj, ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            var storeId = await _storeRepository.GetByUserId(user.Id);

            obj.StoreId = storeId;
            return await Edit(obj);
        }
        public async Task<LocationDto> Create(LocationDto obj)
        {
            //var user = await _userManager.GetUserAsync();
            //var storeId = await _storeRepository.GetByUserId();

            var location =  _locationRepository.Create(new Location
            {
                Country = obj.Country,
                City = obj.City,
                Street = obj.Street,
                PhoneNumaber = obj.PhoneNumaber,
                StoreId = obj.StoreId,
            });

            obj.Id = location.Id;
            return obj;
        }

        public async Task DeleteById(long id)
        {
            _locationRepository.DeleteById(id);
        }

        public async Task<LocationDto> Edit(LocationDto obj)
        {
            var location = _locationRepository.Update(new Location
            {
                Id = obj.Id,
                Country = obj.Country,
                City = obj.City,
                Street = obj.Street,
                PhoneNumaber = obj.PhoneNumaber,
                StoreId = obj.StoreId,
            });

            return obj;
        }

        public async Task<LocationDto> GetById(long id)
        {
            var location = _locationRepository.GetById(id);

            return new LocationDto
            {
                Id = location.Id,
                Country = location.Country,
                City = location.City,
                Street = location.Street,
                PhoneNumaber = location.PhoneNumaber,
                StoreId = location.StoreId,
            };
        }

        //TODO
        public Task<ICollection<LocationDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<LocationDto>> GetLocationsToStore(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            var storeId = await _storeRepository.GetByUserId(user.Id);

            return _locationRepository.GetLocationsToStore(storeId).Select(l => new LocationDto
            {
                Id = l.Id,
                City = l.City,
                Country = l.Country,
                Street = l.Street,
                PhoneNumaber = l.PhoneNumaber,

            }).ToList();
        }
    }
}
