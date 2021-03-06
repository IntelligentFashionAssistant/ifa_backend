using System.Security.Claims;
using System.Text;
using application.DTOs;
using application.exceptions;
using application.persistence;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace application.services
{
    public class StoreService : IStoreService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILocationRepository _locationRepository;
        private readonly IStoreFeedbackRepository _storeFeedbackRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IMailingService _mailingService;
        private readonly IGarmentService _garmentService;

        public StoreService(UserManager<User> userManager,
                            ILocationRepository locationRepository,
                            IStoreFeedbackRepository storeFeedbackRepository,
                            IStoreRepository storeRepository,
                            IMailingService mailingService,
                            IGarmentService garmentService)
        {
            _userManager = userManager;
            _locationRepository = locationRepository;
            _storeFeedbackRepository = storeFeedbackRepository;
            _storeRepository = storeRepository;
            _mailingService = mailingService;
            _garmentService = garmentService;
        }


        public async Task RateStore(ClaimsPrincipal claimsPrincipal, StoreFeedbackDto storeFeedbackDto)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);

            if(user != null)
            {

                 _storeFeedbackRepository.Create(new StoreFeedback()
            {
                Header = storeFeedbackDto.Header, 
                Body = storeFeedbackDto.Body ,
                Rate = storeFeedbackDto.Rate, 
                StoreId = storeFeedbackDto.StoreId, 
                UserId = user.Id,
            });
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<GarmentDto>> GetGarmentsByCategory(ClaimsPrincipal claimsPrincipal, long categoryId)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            var storeId = await _storeRepository.GetByUserId(user.Id);

            return _storeRepository.GetGarmentsByCategory(categoryId, storeId)
                  .Select(garment => new GarmentDto
                  {
                      Id = garment.Id,
                      Name = garment.Name,
                      Brand = garment.Brand,
                      Price = garment.Price,
                      CreatedAt =garment.CreatedAt,
                      CategoryId = garment.CategoryId,
                      Images = garment.Images.Select(img => img.Path).ToList(),
                      SizesOfId = garment.Sizes.Select(s => s.Id).ToList(),
                      ColorsOfId = garment.Colors.Select(c => c.Id).ToList(),
                      Properties = garment.Properties.Select(p => p.Id).ToList(),
                  }).ToList();
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
            };
            var result = await _userManager.CreateAsync(user, obj.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "SHOPOWNER");

                var store = await _storeRepository.Create(new Store
                {
                    Name = obj.StoreName,
                    UserId = user.Id,
                });
                var location = _locationRepository.Create(new Location
                {
                    StoreId = store.Id,
                    Country = obj.Locations.First().Country,
                    City = obj.Locations.First().City,
                    Street = obj.Locations.First().Street,
                    PhoneNumaber = obj.Locations.First().PhoneNumaber,
                });

                var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var encodedEmailToken = Encoding.UTF8.GetBytes(confirmEmailToken);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                string url = $"http://localhost:5001/auth/confirmemail?userid={user.Id}&token={validEmailToken}";

                await _mailingService.SendEmailAsync(user.Email, "Confirm your email", $"<h1>Welcome to Auth Demo</h1>" +
                    $"<p>Please confirm your email by <a href='{url}'>Clicking here</a></p>");

                //await _mailingService.SendEmailAsync(user.Email, "IFA", "Coinfarm");
                return new StoreDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Email = user.Email,
                    Username = user.UserName,
                    StoreName = store.Name,
                    Locations = new List<LocationDto>(){new LocationDto()
                    {
                        Id = location.Id,
                        City = location.City,
                        Country = location.Country,
                        Street = location.Street,
                        PhoneNumaber = location.PhoneNumaber,
                    }}
                };
            }
            else
            {
                throw new CustomException(
                    "error",
                    result.
                        Errors.
                        Select(el => el.Description).
                        ToList());
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

            throw new NotImplementedException();
        }

        public async Task<StoreDto> Edit(StoreDto obj , ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            var storeId = await _storeRepository.GetByUserId(user.Id);

            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.UserName = obj.Username;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var newStore = await _storeRepository.Update(new Store
                {
                    Id = storeId,
                    Name = obj.StoreName,
                });
                return new StoreDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Username = user.UserName,
                    StoreName = newStore.Name,
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
                Username = l.User.UserName,
                CreatedAt = l.CreatedAt,
                Rank = (l.StoreFeedbacks.Count() > 0) ? l.StoreFeedbacks.Sum(feedback => feedback.Rate) / l.StoreFeedbacks.Count() : 1
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
                Username = data.User.UserName,
                BirthDate = data.User.BirthDate,
                Locations = data.Locations.Select(l => new LocationDto
                {
                    Id = l.Id,
                    Country = l.Country,
                    City = l.City,
                    Street = l.Street,
                    PhoneNumaber = l.PhoneNumaber,
                }).ToList(),
                StoreFeedbackDto = data.StoreFeedbacks.Select(feedback => new StoreFeedbackDto()
                {
                    Body = feedback.Body, 
                    Header = feedback.Header, 
                    Rate = feedback.Rate, 
                    UserName = feedback.User.FirstName + ' ' + feedback.User.LastName,
                    UserImage =feedback.User.Phtot
                }).ToList(),
                Rank = (data.StoreFeedbacks.Count() > 0) ? data.StoreFeedbacks.Sum(feedback => feedback.Rate) / data.StoreFeedbacks.Count() : 0

           };

           
        }

        public async Task<long> GetStoreByUserId(long userId)
        { 

            return await _storeRepository.GetByUserId(userId);
        }

        public async Task<bool> Approved(long storeId)
        {
             var store = await _storeRepository.GetById(storeId);
        
            await _mailingService.SendEmailAsync(store.User.Email,
                                    "Registration Accepted", "follow up the link to login  http://localhost:5001/auth/");
           
            return _storeRepository.Approved(storeId);
        }

        public async Task<ICollection<StoreDto>> GetAllNotApproved()
        {
            var data = await _storeRepository.GetAllNotApproved();

            return data.Select(l => new StoreDto
            {
                Id = l.Id,
                StoreName = l.Name,
                FirstName = l.User.FirstName,
                LastName = l.User.LastName,
                BirthDate = l.User.BirthDate,
                Email = l.User.Email,
                Username = l.User.UserName,
                CreatedAt = l.CreatedAt,
            }).ToList();
        }

        public async Task<string> AddPhoto(string photo, ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            var storeId = await _storeRepository.GetByUserId(user.Id);

            return await _storeRepository.AddPhoto(photo, storeId);
        }

        public async Task<StoreDto> Profile(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            var storeId = await _storeRepository.GetByUserId(user.Id);
            var store = await _storeRepository.Profile(storeId);

            return new StoreDto
            {
                Id = store.Id,
                StoreName = store.Name,
                CreatedAt = store.CreatedAt,
                FirstName = store.User.FirstName,
                LastName = store.User.LastName,
                Email = store.User.Email,
                Username = store.User.UserName,
                StorePhoto = (store.PhotoStore) == null ? "img.png" :store.PhotoStore,
                Locations = store.Locations.Select(l => new LocationDto { 
                  Id = l.Id,
                  City = l.City,
                  Country = l.Country,
                  Street = l.Street,
                  PhoneNumaber =l.PhoneNumaber,
                }).ToList(),
            };
        }

        public async Task<bool> Cancel(StoreCancelDto obj)
        {
            var store = await _storeRepository.GetById(obj.StoreId);
             if(store != null)
            {
               await  _mailingService.SendEmailAsync(store.User.Email, obj.Subject, obj.Body);

               await this.DeleteById(store.UserId);
                return true;
            }
            
                throw new Exception("Store not found");         
        }

        public async Task<StoreDto> GetByIdWithGarments(ClaimsPrincipal claimsPrincipal,long storeId,int pageNumber, int pageSize)
        {

            var garmentIds =await _garmentService.GetUserGarmentsByStoreId(claimsPrincipal, storeId, pageNumber, pageSize); 

            var data = await _storeRepository.GetByIdWithGarments(storeId, garmentIds.ToList());

            return new StoreDto
            {
                Id = data.Id,
                StoreName = data.Name,
                FirstName = data.User.FirstName,
                LastName = data.User.LastName,
                Email = data.User.Email,
                Username = data.User.UserName,
                BirthDate = data.User.BirthDate,
                StorePhoto = data.PhotoStore,
                Locations = data.Locations.Select(l => new LocationDto
                {
                    Id = l.Id,
                    Country = l.Country,
                    City = l.City,
                    Street = l.Street,
                    PhoneNumaber = l.PhoneNumaber,
                }).ToList(),
                StoreFeedbackDto = data.StoreFeedbacks.Select(feedback => new StoreFeedbackDto()
                {
                    Body = feedback.Body,
                    Header = feedback.Header,
                    Rate = feedback.Rate,
                    UserName = feedback.User.FirstName + ' ' + feedback.User.LastName,
                    UserImage = feedback.User.Phtot
                }).ToList(),
                Rank = (data.StoreFeedbacks.Count() > 0) ? data.StoreFeedbacks.Sum(feedback => feedback.Rate) / data.StoreFeedbacks.Count() : 0,
                Garments = data.Garments.Select(g => new GarmentDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Brand = g.Brand,
                    Images = g.Images.Select(img => img.Path).ToList(),
                }).ToList(),

            };

        }

        public bool CheckApprove(long userId)
        {
            
            return _storeRepository.CheckApprove(userId);
        }

        public ICollection<StoreFeedbackDto> GetAllFeedbacks(long stroeId)
        {
            var data = _storeRepository.GetAllFeedbacks(stroeId);

            return data.Select(s => new StoreFeedbackDto
            {
                Body = s.Body,
                Rate = s.Rate,
                Id = s.Id,
                UserName = s.User.UserName,
                UserImage = s.User.Phtot == null ? "user.png": s.User.Phtot,
            }).ToList();
        }
    }
}
