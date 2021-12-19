using api.ApiDTOs;
using application.DTOs;
using application.services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    // TODO : add global prefix : /api/v-x
    [Route("/User")]
    public class UserController : Controller
    {
         private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpPost]
        //public IActionResult SearchUsers()
        //{
        //    // return list of matched users
        //    return null;
        //}

        // TODO : move to authentication controller 
        //[HttpPost]
        //public IActionResult Login()
        //{
        //    return null;
        //}


        //*************************************** CRUD ************************************// 
        //[HttpGet("/{id}")]
        //public IActionResult GetUserById()
        //{
        //    return null;
        //}

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
             var data =   _userService.GetAll();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// create new user on register 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserApiDto userApiDto)
        {
            var respons = new ResponsApiDto<UserApiDto>();
            try
            {
                var data = await _userService.CreateUser(new UserDto
                {
                    FirstName = userApiDto.FirstName,
                    LastName = userApiDto.LastName,
                    Email = userApiDto.Email,
                    City = userApiDto.City,
                    Country = userApiDto.Country,
                    BirthDate = userApiDto.BirthDate,
                    Password = userApiDto.Password,
                    Street = userApiDto.Street,
                    HouseNumber = userApiDto.HouseNumber,
                    Username = userApiDto.Username,
                });
                if (data != null)
                {
                    respons.Data = new UserApiDto
                    {
                        Id = data.Id,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        Email = data.Email,
                        City = data.City,
                        Country = data.Country,
                        BirthDate = data.BirthDate,
                        Password = data.Password,
                        Street = data.Street,
                        HouseNumber = data.HouseNumber,
                        Username = data.Username,
                    };
                    respons.Status = "Success";
                    return Ok(respons);
                }
            }
            catch(Exception ex)
            {
                respons.Status = ex.Message;
            }   
            return Ok(respons);
        }

        //[HttpPut]
        //public IActionResult EditUser()
        //{
        //    return null;
        //}

        //[HttpDelete]
        //public IActionResult DeleteUser(long id)
        //{
        //    return null;
        //}
    }
}