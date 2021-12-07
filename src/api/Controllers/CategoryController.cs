using System.Collections.Generic;
using System.Linq;
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

        //[HttpGet("/{id:int}")]
        //public IActionResult GetCategoryById(long id)
        //{
        //    var response = new ResponsApiDto<CateogryApiDTO>();
        //    var data = _categoryService.GetById(id);

        //    if (data != null)
        //    {
        //        response.Data = new CateogryApiDTO
        //        {
        //            Id = data.Id,
        //            Name = data.Name,
        //            Description = data.Description
        //        };
        //        response.Status = "Success";
        //        return Ok(response);
        //    }

        //    response.Status = "Failed";
        //    // TODO : change ok to appropriate result 
        //    return Ok(response);
        //}
        
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var response = new ResponsApiDto<ICollection<CateogryApiDTO>>();
            var data = _categoryService.GetAll();

            if (data != null)
            {
                response.Data = data.Select(c => new CateogryApiDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }).ToList();
                response.Status = "Success";
                return Ok(response.Data);
            }
            response.Status = "Failed";
            return Ok(response.Data);
        }

        [HttpPost]
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
        
        [HttpPut]
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
        
        [HttpDelete]
        public IActionResult DeleteCategory(long id)
        {
            _categoryService.DeleteById(id);
            return Ok();
        }
    }
}