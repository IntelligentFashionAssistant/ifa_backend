using api.ApiDTOs;
using application.DTOs;
using application.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var response = new ResponsApiDto<ICollection<GroupApiDto>,string>();

            try
            {
                var data = _groupService.GetAll();

                response.Data = data.Select(gruop => new GroupApiDto
                {
                    Id = gruop.Id,
                    Name = gruop.Name,
                    Description = gruop.Description,
                    CategorysNames = gruop.CategorysNames,
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
        public IActionResult CreateGroup(GroupApiDto groupApiDto)
        {
            var response = new ResponsApiDto<GroupApiDto,string>();

            try {
                var data = _groupService.Create(
                    new GroupDto
                    {
                        Name = groupApiDto.Name,
                        Description = groupApiDto.Description,
                        Categorys = groupApiDto.Categorys,
                    });
                if (data != null)
                {
                    response.Data = new GroupApiDto
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Description = data.Description,
                        Categorys = data.Categorys,
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
        public IActionResult EditGroupy(GroupApiDto groupApiDto)
        {
            var response = new ResponsApiDto<GroupApiDto, string>();

            try
            {
                var data = _groupService.Edit(
                    new GroupDto
                    {
                        Id = groupApiDto.Id,
                        Name = groupApiDto.Name,
                        Description = groupApiDto.Description,
                        Categorys = groupApiDto.Categorys,
                    });
                if (data != null)
                {
                    response.Data = new GroupApiDto
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Description = data.Description,
                        Categorys = data.Categorys,
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
        public IActionResult DeleteGroup(long id)
        {
            var response = new ResponsApiDto<long, string>();
            try
            {
                _groupService.DeleteById(id);
                response.Data = id;
            }
            catch (Exception ex)
            {
                response.AddError("Not found");
                return NotFound(response);
            }
           
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetGroupById(long id)
        {
            var response = new ResponsApiDto<GroupApiDto, string>();

            try
            {
                var data = _groupService.GetById(id); 
                 
                 if(data != null)
                {
                    response.Data = new GroupApiDto
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Description = data?.Description,
                        Categorys = data?.Categorys,
                        CategorysNames = data?.CategorysNames,
                    };
                }

            }catch (Exception ex)
            {
                response.AddError(ex.Message);
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
