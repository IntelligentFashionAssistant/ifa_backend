using api.ApiDTOs;
using application.services;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UAParser;

namespace api.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController : Controller
{
    private readonly IAuthService _authservice;
    private readonly IStoreService _storeService;
    private readonly UserManager<User> _userManager;
    public AuthController(IAuthService authService,
                            IStoreService storeService,
                            UserManager<User> userManager)
    {
         _authservice = authService;
         _storeService = storeService;
         _userManager = userManager;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Authenticate(string userEmail, string password)
    {
        var response = new ResponsApiDto<string, string>();
        var userAgent = HttpContext.Request.Headers["User-Agent"];
        var uaParser = Parser.GetDefault();
        ClientInfo c = uaParser.Parse(userAgent);

        try
        {
            var auth = await _authservice.ValidateUser(userEmail, password);
            if (! auth )
            {
                response.AddError("Username or Password Invalid");
                return BadRequest(response);
            }

              var user = await _userManager.FindByEmailAsync(userEmail);
          
              var role = await _userManager.GetRolesAsync(user);

            //check user and clinet type
             if(role[0].ToLower().Equals("ShopOwner".ToLower()) && c.ToString().ToLower().Contains("chrome"))
            {
                response.AddError("you are not allowed to login from the mobile client");
                return BadRequest(response);
            }

            if (role[0].ToLower().Equals("ShopOwner".ToLower()))
            {
                var a = _storeService.CheckApprove(user.Id);

                   if(! a)
                {
                    response.AddError("Wait while the admin approves of you");
                    return BadRequest(response);
                }
            }
           
        }
        catch(Exception ex)
        {
            response.AddError(ex.Message);
            return BadRequest(response);
        }
        

        response.Data = await _authservice.CreateToken();
        return Ok(response);
    }

    [HttpPost("CheckEmail")]
    public async Task<IActionResult> CheckEmail([FromForm] string userEmail)
    {
        var response = new ResponsApiDto<bool, string>();

        try
        {
            response.Data =await _authservice.EmailIsExist(userEmail);
           
        }
        catch(Exception ex)
        {
            response.AddError(ex.Message);
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        var response = new ResponsApiDto<string, string>();

        if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
            return NotFound();

        try
        {
            var result = await _authservice.ConfirmEmailAsync(userId, token);
            return Redirect($"http://localhost:4200/auth");
            response.Data = result;
        }
        catch (Exception ex)
        {
            response.AddError(ex.Message);
            return BadRequest(response); 
        }


        //if (result.IsSuccess)
        //{
        //    return Redirect($"{_configuration["AppUrl"]}/ConfirmEmail.html");
        //}

        return Ok(response);
    }
}