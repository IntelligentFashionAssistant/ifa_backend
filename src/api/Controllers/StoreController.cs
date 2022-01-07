using api.ApiDTOs;
using application.DTOs;
using application.services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/store")]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        //[HttpPost]
        //public IActionResult RateStore()
        //{
        //    return null;
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(long storeId)
        {
            var response = new ResponsApiDto<StoreApiDto, string>();

            try
            {
                var data = await _storeService.GetById(storeId);  

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
                        BirthDate = data.BirthDate,
                        LastName = data.LastName,
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
        public async Task<IActionResult> GetAllStores()
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
                    PhoneNumber = storeApiDto.PhoneNumber,
                    //Country = storeApiDto.Country,
                    //City = storeApiDto.City,
                    Username = storeApiDto.Username,
                    StoreName = storeApiDto.StoreName,
                    //Street = storeApiDto.Street,
                });
                 if(data != null)
                {
                    response.Data = new StoreApiDto
                    {
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        StoreName = data.StoreName,
                        Email = data.Email,
                        BirthDate = data.BirthDate,
                        //Country = data.Country,
                        //City = data.City,
                        //Street = data.Street,
                        PhoneNumber = data.PhoneNumber,
                        Username = data.Username,
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
        
        [HttpPut]
        public async Task<IActionResult> EditStore(StoreApiDto storeApiDto)
        {

            var response = new ResponsApiDto<StoreApiDto, string>();

            try
            {
                var data = await _storeService.Create(new StoreDto
                {
                    Id = storeApiDto.Id,
                    FirstName = storeApiDto.FirstName,
                    LastName = storeApiDto.LastName,
                    BirthDate = storeApiDto.BirthDate,
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
    }
}