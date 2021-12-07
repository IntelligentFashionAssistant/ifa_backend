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
            var respons = new ResponsApiDto<ICollection<PropertyApiDto>>();
            var data = _propertyService.GetAll();


            respons.Data = data.Select(property => new PropertyApiDto
            {
                Id = property.Id,
                Name = property.Name,
                Description = property.Description,
                //Category = property.Category,
                Group = property.Group,

            }).ToList();
            respons.Status = "Success";
                return Ok(respons.Data);
        }
        
        
        [HttpPost]
        public IActionResult CreateProperty(PropertyApiDto propertyApiDto)
        {
            var respons = new ResponsApiDto<PropertyApiDto>();
            var data = _propertyService.Create(new PropertyDto
            {
                Name = propertyApiDto.Name,
                Description = propertyApiDto.Description,
                //CategoryId = propertyApiDto.CategoryId,
                GroupId =  propertyApiDto.GroupId,
            });
            if(data != null)
            {
                respons.Data = new PropertyApiDto
                {
                    Id = data.Id,
                    Description = data.Description,
                    //CategoryId = data.CategoryId,
                    GroupId = data.GroupId,
                    Name = data.Name
                };
                respons.Status = "Success";
                return Ok(respons);
            }
            return BadRequest();
        }
        
        [HttpPut]
        public IActionResult EditProperty(PropertyApiDto propertyApiDto)
        {
            var respons = new ResponsApiDto<PropertyApiDto>();
            var data = _propertyService.Edit(new PropertyDto
            {
                Id = propertyApiDto.Id,
                Name = propertyApiDto.Name,
                Description = propertyApiDto.Description,
                //CategoryId = propertyApiDto.CategoryId,
                GroupId = propertyApiDto.GroupId,
            });
            if (data != null)
            {
                respons.Data = new PropertyApiDto
                {
                    Id = data.Id,
                    Description = data.Description,
                    //CategoryId = data.CategoryId,
                    GroupId = data.GroupId,
                    Name =data.Name
                };
                respons.Status = "Success";
                return Ok(respons);
            }
            return BadRequest();
        }
        
        [HttpDelete]
        public IActionResult DeleteProperty(long id)
        {
            _propertyService.DeleteById(id);

            return Ok();
        }
    }
}