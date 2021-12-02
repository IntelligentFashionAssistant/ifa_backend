using api.ApiDTOs;
using application.services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/category")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/{id:int}")]
        public IActionResult GetCategoryById(long id)
        {
            var respons = new ResponsApiDto<CateogryApiDTO>();
            var data = _categoryService.GetById(id);

            if (data != null)
            {
                respons.Data = new CateogryApiDTO
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description
                };
                respons.Status = "Success";
                return Ok(respons);
            }

            respons.Status = "Failed";
            return Ok(respons);
        }
        
        [HttpGet("/")]
        public IActionResult GetAllCategories()
        {
            var respons = new ResponsApiDto<ICollection<CateogryApiDTO>>();
            var data = _categoryService.GetAll();

            if (data != null)
            {
                respons.Data = data.Select(c => new CateogryApiDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }).ToList();
                respons.Status = "Success";
                return Ok(respons);
            }
            respons.Status = "Failed";
            return Ok(respons);
        }

        [HttpPost("/")]
        public IActionResult CreateCategory(CateogryApiDTO cateogryApiDto)
        {  
            var respons = new ResponsApiDto<CateogryApiDTO>();
            var data = _categoryService.Create(new CategoryDto
            {
                Description = cateogryApiDto.Description,
                Name = cateogryApiDto.Name,
            });
             
            if(data != null)
            {
                respons.Data = new CateogryApiDTO
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description
                };
                respons.Status = "Success";
                return Ok(respons);
            }
           
            respons.Status ="Failed";
            return Ok(respons);
        }
        
        [HttpPut("/")]
        public IActionResult EditCategory(CateogryApiDTO cateogryApiDto)
        {
            var respons = new ResponsApiDto<CateogryApiDTO>();
            var data = _categoryService.Edit(new CategoryDto
            {
                Id = cateogryApiDto.Id,
                Description = cateogryApiDto.Description,
                Name = cateogryApiDto.Name,
            });

            if (data != null)
            {
                respons.Data = new CateogryApiDTO
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description
                };
                respons.Status = "Success";
                return Ok(respons);
            }

            respons.Status = "Failed";
            return Ok(respons);
        }
        
        [HttpDelete("/{id:int}")]
        public IActionResult DeleteCategory(long id)
        {
            _categoryService.DeleteById(id);

            return Ok();
        }
    }
}