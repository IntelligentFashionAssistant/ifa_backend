using System.Collections.Generic;
using System.Linq;
using api.ApiDTOs;
using application.services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id:int}")]
        public IActionResult GetCategoryById(long id)
        {
            var response = new ResponsApiDto<CateogryApiDTO,string>();

            try
            {
                var data = _categoryService.GetById(id);

                if (data != null)
                {
                    response.Data = new CateogryApiDTO
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Description = data.Description
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

        //[Authorize]
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var response = new ResponsApiDto<ICollection<CateogryApiDTO>,string>();

            try
            {
                var data = _categoryService.GetAll();

                if (data != null)
                {
                    response.Data = data.Select(c => new CateogryApiDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description,
                        NumberOfGroups = c.NumberOfGroups,
                    }).ToList();
                   
                }
            }
            catch(Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);
            }
            return Ok(response);

        }

       // [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult CreateCategory(CateogryApiDTO cateogryApiDto)
        {
            var respons = new ResponsApiDto<CateogryApiDTO,string>();
            var data = _categoryService.Create(new CategoryDto
            {
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
                return Ok(respons);
            }

            respons.AddError("Failed");
            return BadRequest(respons);
        }

        [HttpPut]
        public IActionResult EditCategory(CateogryApiDTO cateogryApiDto)
        {
            var respons = new ResponsApiDto<CateogryApiDTO,string>();
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
                return Ok(respons);
            }

            respons.AddError("Failed");
            return BadRequest(respons);
        }

        [HttpDelete("{id:long}")]
        public IActionResult DeleteCategory(long id)
        {
            //TODO throu exption
            var respons = new ResponsApiDto<long, string>();
            try
            {
                _categoryService.DeleteById(id);
                respons.Data = id;
            }
            catch(Exception ex)
            {
                respons.AddError(ex.Message);
                return NotFound(respons);
            }
            return Ok(respons);
        }
    }
}