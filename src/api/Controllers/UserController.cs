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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var respons = new ResponsApiDto<UserApiDto>();
            try
            {
                var data = await _userService.GetUserById(id);
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
                        Street = data.Street,
                        HouseNumber = data.HouseNumber,
                        Username = data.Username,
                        PhoneNumber = data.PhoneNumber,
                    };
                    respons.Status = "Success";
                    return Ok(respons);
                }
            }
            catch (Exception ex)
            {
                respons.Status =ex.Message;
            }

          
           
            return NotFound(respons);
        }

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
            if (!ModelState.IsValid)
            {
                BadRequest(userApiDto);
            }
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

        [HttpPut]
        public async Task<IActionResult> EditUser(UserApiDto userApiDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(userApiDto);
            }
            var respons = new ResponsApiDto<UserApiDto>();
            try
            {
                var data = await _userService.EditUser(new UserDto
                { 
                    
                    Id = userApiDto.Id,
                    FirstName = userApiDto.FirstName,
                    LastName = userApiDto.LastName,
                    City = userApiDto.City,
                    Country = userApiDto.Country,
                    BirthDate = userApiDto.BirthDate,
                    Street = userApiDto.Street,
                    HouseNumber = userApiDto.HouseNumber,
                    Username = userApiDto.Username,
                    PhoneNumber = userApiDto.PhoneNumber,
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
                        PhoneNumber = data.PhoneNumber,
                    };
                    respons.Status = "Success";
                    return Ok(respons);
                }
            }
            catch (Exception ex)
            {
                respons.Status = ex.Message;
            }
            return Ok(respons);
        }

        [HttpDelete]
        public IActionResult DeleteUser(long id)
        {
            var respons = new ResponsApiDto<long>();

            try
            {
                _userService.DeleteUserById(id);
                respons.Data = id;
                respons.Status = "Success";
                return Ok(respons);
            }
            catch (Exception ex)
            {
                respons.Status = ex.Message;
            }

            return BadRequest(respons);
        }
    }
}