using api.ApiDTOs;
using application.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("/Location")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLocationById(long id)
        {
            var response = new ResponsApiDto<LocationApiDto, string>();

            try
            {
                var data = await _locationService.GetById(id);

                if (data != null)
                {
                    response.Data = new LocationApiDto
                    {
                        Id = data.Id,
                        Country = data.Country,
                        City = data.City,
                        PhoneNumber = data.PhoneNumaber,
                        Street = data.Street,
                        StoreId = data.StoreId,
                    };

                }
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return NotFound(response);
            }

            return Ok(response);
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllLocationsToStore()
        {
            var response = new ResponsApiDto<ICollection<LocationApiDto>, string>();

            try
            {
                var data = await _locationService.GetLocationsToStore(User);
                    response.Data = data.Select(locatio => new LocationApiDto
                    {
                        Id = locatio.Id,
                        Country = locatio.Country,
                        City = locatio.City,
                        PhoneNumber = locatio.PhoneNumaber,
                        Street = locatio.Street,
                        StoreId = locatio.StoreId,
                    }).ToList();
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return NotFound(response);
            }
            return Ok(response);

        }

       
        [HttpPost]
        public async Task<IActionResult> CreateLocation(LocationApiDto locationApiDto)
        {
            var respons = new ResponsApiDto<LocationApiDto, string>();
            try
            {
                var data = await _locationService.CreateLocation(new LocationDto
                {
                    Country = locationApiDto.Country,
                    City = locationApiDto.City,
                    PhoneNumaber = locationApiDto.PhoneNumber,
                    Street = locationApiDto.Street,
                }, User);

                if (data != null)
                {
                    respons.Data = new LocationApiDto
                    {
                        Id = data.Id,
                        Country = data.Country,
                        City = data.City,
                        PhoneNumber = data.PhoneNumaber,
                        Street = data.Street,
                    };
                }
            }
            catch(Exception ex)
            {
                respons.AddError(ex.Message);
                return BadRequest(respons);
            }

            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> EditLocation(LocationApiDto locationApiDto)
        {
            var respons = new ResponsApiDto<LocationApiDto, string>();
            try
            {
                var data = await _locationService.EditLocation(new LocationDto
                {
                    Id = locationApiDto.Id,
                    Country = locationApiDto.Country,
                    City = locationApiDto.City,
                    PhoneNumaber = locationApiDto.PhoneNumber,
                    Street = locationApiDto.Street,

                }, User);

                if (data != null)
                {
                    respons.Data = new LocationApiDto
                    {
                        Id = data.Id,
                        Country = data.Country,
                        City = data.City,
                        PhoneNumber = data.PhoneNumaber,
                        Street = data.Street,
                    };
                   
                }
            }
            catch (Exception ex)
            {
                respons.AddError(ex.Message);
                return BadRequest(respons);
            }
            return Ok(respons);
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteLocation(long id)
        {
            
            var respons = new ResponsApiDto<long, string>();
            try
            {
                 _locationService.DeleteById(id);
                  respons.Data = id;
            }

            catch (Exception ex)
            {
                respons.AddError(ex.Message);
                return NotFound(respons);
            }
            return Ok(respons);
        }
    }
}
