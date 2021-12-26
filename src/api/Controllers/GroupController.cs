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
            var response = new ResponsApiDto<ICollection<GroupApiDto>, string>();
            var data = _groupService.GetAll();

             if(data != null)
            {
                response.Data = data.Select(gruop => new GroupApiDto
                {
                    Id = gruop.Id,
                    Name = gruop.Name,
                    Description = gruop.Description,
                    Category = gruop.Category,
                    CategoryId = gruop.CategoryId,

                }).ToList();
                return Ok(response.Data);
            }

            response.AddError("Not found");
            return NotFound(response);
        }

        [HttpPost]
        public IActionResult CreateGroup(GroupApiDto groupApiDto)
        {
            var response = new ResponsApiDto<GroupApiDto, string>();
            var data = _groupService.Create(
                 new GroupDto
                 {
                     Name = groupApiDto.Name,
                     Description = groupApiDto.Description,
                     CategoryId = groupApiDto.CategoryId,
                 });
            if (data != null)
            {
                response.Data = new GroupApiDto
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description,
                    CategoryId = data.CategoryId,
                };
                return Ok(response);
            }
            response.AddError("Not Created");
            return BadRequest(response);
        }

        [HttpPut]
        public IActionResult EditGroupy(GroupApiDto groupApiDto)
        {
            var response = new ResponsApiDto<GroupApiDto,string>();
            var data = _groupService.Edit(
                 new GroupDto
                 {
                     Id = groupApiDto.Id,
                     Name = groupApiDto.Name,
                     Description = groupApiDto.Description,
                     CategoryId = groupApiDto.CategoryId,
                 });
            if (data != null)
            {
                response.Data = new GroupApiDto
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description,
                    CategoryId = data.CategoryId,
                };
               
                return Ok(response);
            }
            response.AddError("Not Updated");
            return BadRequest(response);
        }

        [HttpDelete]
        public IActionResult DeleteGroup(long id)
        {
            var response = new ResponsApiDto<long, string>();


              _groupService.DeleteById(id);
                response.Data = id;
                return Ok(response);  
        }
    }
}
