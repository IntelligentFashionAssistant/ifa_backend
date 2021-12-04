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
            var response = new ResponsApiDto<ICollection<GroupApiDto>>();
            var data = _groupService.GetAll();

             response.Data = data.Select(gruop => new GroupApiDto
                {   
                    Id = gruop.Id,
                    Name = gruop.Name,
                    Description = gruop.Description,
                    CategoryId = gruop.CategoryId,
                    
                }).ToList();
                response.Status = "Success";
                return Ok(response);

        }

        [HttpPost]
        public IActionResult CreateGroup(GroupApiDto groupApiDto)
        {
            var response = new ResponsApiDto<GroupApiDto>();
            var data = _groupService.Create(
                 new GroupDto
                 {
                     Name = groupApiDto.Name,
                     Description = groupApiDto.Description,
                     CategoryId = groupApiDto.CategoryId,
                 });
            if(data != null)
            {
                response.Data = new GroupApiDto
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description,
                    CategoryId = data.CategoryId,
                };
                response.Status = "Success";
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult EditGroupy(GroupApiDto groupApiDto)
        {
            var response = new ResponsApiDto<GroupApiDto>();
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
                response.Status = "Success";
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteGroup(long id)
        {
            _groupService.DeleteById(id);
            return Ok();
        }
    }
}
