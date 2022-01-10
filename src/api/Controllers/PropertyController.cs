using api.ApiDTOs;
using application.DTOs;
using application.services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/property")]
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        //[HttpGet("/{id}")]
        //public IActionResult GetPropertyById(long id)
        //{
        //    return null;
        //}

        [HttpGet]
        public IActionResult GetAllProperties()
        {
            var respons = new ResponsApiDto<ICollection<PropertyApiDto>, string>();

            try
            {
                var data = _propertyService.GetAll();


                respons.Data = data.Select(property => new PropertyApiDto
                {
                    Id = property.Id,
                    Name = property.Name,
                    Description = property.Description,
                    GroupId = property.GroupId,
                    Group = property.Group,

                }).ToList();
            }
            catch (Exception ex)
            {
                respons.AddError(ex.Message);
                return NotFound(respons);
            }

            return Ok(respons);
        }


        [HttpPost]
        public IActionResult CreateProperty(PropertyApiDto propertyApiDto)
        {
            var respons = new ResponsApiDto<PropertyApiDto, string>();

            try
            {
                var data = _propertyService.Create(new PropertyDto
                {
                    Name = propertyApiDto.Name,
                    Description = propertyApiDto.Description,
                    GroupId = propertyApiDto.GroupId,
                });
                if (data != null)
                {
                    respons.Data = new PropertyApiDto
                    {
                        Id = data.Id,
                        Description = data.Description,
                        GroupId = data.GroupId,
                        Name = data.Name
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

        [HttpPut]
        public IActionResult EditProperty(PropertyApiDto propertyApiDto)
        {
            var respons = new ResponsApiDto<PropertyApiDto, string>();

            try
            {
                var data = _propertyService.Edit(new PropertyDto
                {
                    Id = propertyApiDto.Id,
                    Name = propertyApiDto.Name,
                    Description = propertyApiDto.Description,
                    GroupId = propertyApiDto.GroupId,
                });
                if (data != null)
                {
                    respons.Data = new PropertyApiDto
                    {
                        Id = data.Id,
                        Description = data.Description,
                        GroupId = data.GroupId,
                        Name = data.Name
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

        [HttpDelete]
        public IActionResult DeleteProperty(long id)
        {
            var respons = new ResponsApiDto<long, string>();
            try
            {
                _propertyService.DeleteById(id);
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