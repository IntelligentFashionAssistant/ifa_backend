using api.ApiDTOs;
using application.DTOs;
using application.services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    // TODO : add global prefix : /api/v-x
    [Route("/user")]
    public class CustomerController : Controller
    {
         private readonly ICustomerService _customerService;
         private readonly IAuthService _authservice;
        public CustomerController(ICustomerService customerService, IAuthService authService)
        {
            _customerService = customerService;
            this._authservice = authService;
        }

        [HttpPost("/calculatebodyshape")]
        public async Task<IActionResult> CalculateBodyShape(BodySizesApiDto bodySizesApiDto)
        {
            var bodySizesDto = new BodySizesDto()
            {
                Id = bodySizesApiDto.Id,
                BustSize = bodySizesApiDto.BustSize,
                HipSize = bodySizesApiDto.HipSize,
                ShoulderSize = bodySizesApiDto.ShoulderSize,
                WaistSize = bodySizesApiDto.WaistSize
            };
            
            var respons = new ResponsApiDto<CustomerApiDto,string>();

            try
            {
                var data = await _customerService.CalculateBodyShape(User, bodySizesDto);
                respons.Data = new CustomerApiDto() 
                    {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    City = data.City,
                    Country = data.Country,
                    Street = data.Street,
                    Username = data.Username,
                    PhoneNumber = data.PhoneNumber,
                    BustSize = data.BustSize,
                    HipSize = data.HipSize,
                    ShoulderSize = data.ShoulderSize,
                    WaistSize = data.WaistSize,
                    Shape = data.Shape
                    };
                return Ok(respons); 
            }
            catch (Exception e)
            {
                respons.AddError(e.Message);
                return BadRequest(respons);
            }
        }

        
        //*************************************** CRUD ************************************// 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var respons = new ResponsApiDto<CustomerApiDto,string>();
            try
            {
                var data = await _customerService.GetById(id);
                if (data != null)
                {
                    respons.Data = new CustomerApiDto() 
                    {
                        Id = data.Id,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        Email = data.Email,
                        City = data.City,
                        Country = data.Country,
                        BirthDate = data.BirthDate,
                        Street = data.Street,
                        Username = data.Username,
                        PhoneNumber = data.PhoneNumber,
                    };
                }
                else
                {
                    respons.Data = null;
                }
                return Ok(respons);
            }
            catch (Exception ex)
            {
                respons.AddError(ex.Message);
                return BadRequest(respons);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var respons = new ResponsApiDto<List<CustomerApiDto>,string>();
            try
            {
             var data =  await  _customerService.GetAll();
             respons.Data = data.Select(data => new CustomerApiDto()
             {
                 Id = data.Id,
                 FirstName = data.FirstName,
                 LastName = data.LastName,
                 Email = data.Email,
                 City = data.City,
                 Country = data.Country,
                 Street = data.Street,
                 Username = data.Username,
                 PhoneNumber = data.PhoneNumber,
             }).ToList();
            }
            catch (Exception ex)
            {
                respons.AddError(ex.Message);
                return BadRequest(respons);
            }
            return Ok(respons);

        }

        /// <summary>
        /// create new user on register 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(CustomerApiDto userApiDto)
        {
            var respons = new ResponsApiDto<CustomerApiDto,string>();

            try
            {

                await _authservice.EmailIsExist(userApiDto.Email);

                var data = await _customerService.Create(new CustomerDto
                {
                    Email = userApiDto.Email,
                    Username = userApiDto.Username,
                    Password = userApiDto.Password
                });
                
                if (data != null)
                {
                    respons.Data = new CustomerApiDto() 
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
                        Username = data.Username,
                    };
                    
                    return Ok(respons);
                }
            }
            catch(Exception ex)
            {
                respons.AddError(ex.Message);
            }   
            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> EditUser(CustomerApiDto userApiDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(userApiDto);
            }
            var respons = new ResponsApiDto<CustomerApiDto,string>();
            try
            {
                var data = await _customerService.Edit(new CustomerDto
                { 
                    
                    Id = userApiDto.Id,
                    FirstName = userApiDto.FirstName,
                    LastName = userApiDto.LastName,
                    City = userApiDto.City,
                    Country = userApiDto.Country,
                    BirthDate = userApiDto.BirthDate,
                    Street = userApiDto.Street,
                    Username = userApiDto.Username,
                    PhoneNumber = userApiDto.PhoneNumber,
                });
                if (data != null)
                {
                    respons.Data = new CustomerApiDto()
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
                        Username = data.Username,
                        PhoneNumber = data.PhoneNumber,
                    };
                    return Ok(respons);
                }
            }
            catch (Exception ex)
            {
                respons.AddError(ex.Message);
            }
            return Ok(respons);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var respons = new ResponsApiDto<long,string>();

            try
            {
                await _customerService.DeleteById(id);
                respons.Data = id;
                return Ok(respons);
            }
            catch (Exception ex)
            {
                respons.AddError(ex.Message);
            }

            return BadRequest(respons);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var respons = new ResponsApiDto<CustomerApiDto, string>();

            try
            {
                var data = await _customerService.Profile(User);

                if(data != null)
                {
                    respons.Data = new CustomerApiDto
                    {
                        Id = data.Id,
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        Email = data.Email,
                        PhoneNumber = data.PhoneNumber,
                        Photo = data.Photo,
                        Country = data.Country,
                        BirthDate = data.BirthDate,
                        City = data.City,
                        Street = data.Street,
                        Shape = data.Shape,
                        BustSize = data.BustSize,
                        HipSize = data.HipSize,
                        ShoulderSize = data.ShoulderSize,
                        WaistSize = data.WaistSize,
                        Username = data.Username,
                        Sizes = data.Sizes,

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
    }
}