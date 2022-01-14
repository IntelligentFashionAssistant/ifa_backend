using api.ApiDTOs;
using application.DTOs;
using application.exceptions;
using application.services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/store")]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IImageService _imageService;

        public StoreController(IStoreService storeService , IImageService imageService)
        {
            _storeService = storeService;
            _imageService = imageService;
        }
        
        
        [HttpPost("rate")]
        public async Task<IActionResult> RateStore(StoreFeedbackApiDto storeFeedbackApiDto)
        {
            var response = new ResponsApiDto<string, string>();
            try {
               await _storeService.RateStore(User, new StoreFeedbackDto()
                {
                    Header = storeFeedbackApiDto.Header, 
                    Body = storeFeedbackApiDto.Body ,
                    Rate = storeFeedbackApiDto.Rate, 
                    StoreId = storeFeedbackApiDto.StoreId, 
                });
                response.Data = "Succeed";
            }
            catch(Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(long id)
        {
            var response = new ResponsApiDto<StoreApiDto, string>();

            try
            {
                var data = await _storeService.GetById(id);  

                if(data != null)
                {
                    response.Data = new StoreApiDto
                    {
                        Id = data.Id,
                        StoreName = data.StoreName,
                        FirstName = data.FirstName,
                        CreatedAt = data.CreatedAt,
                        Email = data.Email,
                        PhoneNumber = data.PhoneNumber,
                        Username = data.Username,
                        LastName = data.LastName,
                        Rank = data.Rank,
                        Locations = data.Locations.Select(location => new LocationApiDto
                        {
                            Id = location.Id,
                            Country = location.Country,
                            City = location.City,
                            Street = location.Street,
                        }).ToList(),
                    };
                }
            }
            catch(Exception ex)
            {
                response.AddError(ex.Message);
                return NotFound(response); 
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStoresApproved()
        {
            var response = new ResponsApiDto<ICollection<StoreApiDto>, string>();

            try {
                var data = await _storeService.GetAll();

                response.Data = data.Select(store => new StoreApiDto
                {
                    Id = store.Id,
                    StoreName = store.StoreName,
                    FirstName = store.FirstName,
                    LastName = store.LastName,
                    CreatedAt = store.CreatedAt,
                    Email = store.Email,
                    PhoneNumber = store.PhoneNumber,
                    Username = store.Username,
                    Rank = store.Rank,
                }).ToList();
            }
            catch(Exception ex)
            {
                response.AddError(ex.Message);
                response.Data = new List<StoreApiDto>();
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("StoresNotApproved")]
        public async Task<IActionResult> GetAllStoresNotApproved()
        {
            var response = new ResponsApiDto<ICollection<StoreApiDto>, string>();

            try
            {
                var data = await _storeService.GetAllNotApproved();

                response.Data = data.Select(store => new StoreApiDto
                {
                    Id = store.Id,
                    StoreName = store.StoreName,
                    FirstName = store.FirstName,
                    LastName = store.LastName,
                    CreatedAt = store.CreatedAt,
                    Email = store.Email,
                    PhoneNumber = store.PhoneNumber,
                    Username = store.Username,
                    Rank = store.Rank,
                }).ToList();
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                response.Data = new List<StoreApiDto>();
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(StoreApiDto storeApiDto)
        {
            var response = new ResponsApiDto<StoreApiDto, string>();

            try
            {
                var data = await _storeService.Create(new StoreDto
                {
                    FirstName = storeApiDto.FirstName,
                    LastName = storeApiDto.LastName,
                    BirthDate = storeApiDto.BirthDate,
                    Email = storeApiDto.Email,
                    Password = storeApiDto.Password,
                    Username = storeApiDto.Username,
                    StoreName = storeApiDto.StoreName,
                    Rank = storeApiDto.Rank,
                    CreatedAt = storeApiDto.CreatedAt,
                    Locations = storeApiDto.Locations.Select(l => new LocationDto
                    {
                        Country = l.Country,
                        City = l.City,
                        Street = l.Street,
                        PhoneNumaber = l.PhoneNumber,
                    }).ToList()
                }) ;
                 if(data != null)
                {
                    response.Data = new StoreApiDto
                    {  
                        Id = data.Id,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        StoreName = data.StoreName,
                        Email = data.Email,
                        BirthDate = data.BirthDate,
                        Locations = data.Locations.Select(l => new LocationApiDto
                        {
                            Id = l.Id,
                            Country = l.Country,
                            City = l.City,
                            Street = l.Street,
                            PhoneNumber = data.PhoneNumber,
                        }).ToList(),
                        Username = data.Username,
                    };
                    
                }
            }
            catch (CustomException ex)
            {
                ex.ErrorMessages.ForEach(m =>
                {
                    response.AddError(m);
                });
               
                return BadRequest(response);
            }
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> EditStore(StoreApiDto storeApiDto)
        {

            var response = new ResponsApiDto<StoreApiDto, string>();

            try
            {
                var data = await _storeService.Edit(new StoreDto
                {
                    Id = storeApiDto.Id,
                    FirstName = storeApiDto.FirstName,
                    LastName = storeApiDto.LastName,
                    PhoneNumber = storeApiDto.PhoneNumber,
                    Username = storeApiDto.Username,
                    StoreName = storeApiDto.StoreName,
                });
                if (data != null)
                {
                    response.Data = new StoreApiDto
                    {
                        Id = data.Id,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        StoreName = data.StoreName,
                        BirthDate = data.BirthDate,
                        PhoneNumber = data.PhoneNumber,
                        Username = data.Username,
                        Email = data.Email,
                    };

                }
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);
            }
            return Ok(response);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteStore(long storeId)
        {
            var response = new ResponsApiDto<long, string>();

            try{
              await  _storeService.DeleteById(storeId);
                 response.Data = storeId;
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("GetGarmentsByCategory")]
        public async Task<IActionResult> GetGarmentsByCategory(long categoryId)
        {
            var response = new ResponsApiDto<ICollection<GarmentApiDto>, string>();

            try
            {
                var data = await _storeService.GetGarmentsByCategory(User, categoryId);

                 response.Data = data.Select(garment => new GarmentApiDto
                 {
                     Id = garment.Id,
                     Name = garment.Name,
                     Price = garment.Price,
                     Brand = garment.Brand,
                     CategoryId = garment.CategoryId,
                     CreatedAt = garment.CreatedAt,
                     Images = garment.Images,
                     Properties = garment.Properties,
                     ColorsOfId = garment.ColorsOfId,
                     SizesOfId = garment.SizesOfId,
                 }).ToList();

            }catch (Exception ex)
            {
                response.AddError(ex.Message);
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("Approved/{stroeId:long}")]
        public IActionResult Approved(long stroeId)
        {
            var response = new ResponsApiDto<string, string>();

            try
            {
            var data = _storeService.Approved(stroeId);
                response.Data = "Approved";
            }
            catch(Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);
            }
            return Ok(response); 
        }

        [HttpPost("AddPhoto")]
        public async Task<IActionResult> AddPhoto(IFormFile photo)
        {
            var response = new ResponsApiDto<string, string>();

            try
            {
                 if(photo == null)
                {
                    response.AddError("the photo is required");
                    return BadRequest(response);
                }

                var photoName = await _imageService.SaveOneIamge(photo);
                response.Data = await _storeService.AddPhoto(photoName, User);

            }catch(Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
      
    public class StoreFeedbackApiDto
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int Rate { get; set; }
        public long? StoreId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
    }
}