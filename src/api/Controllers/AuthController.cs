using api.ApiDTOs;
using application.services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController : Controller
{
    private readonly IAuthService _authservice;

    public AuthController(IAuthService authService)
    {
        this._authservice = authService;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Authenticate(string userEmail, string password)
    {
        var response = new ResponsApiDto<string, string>();

        if (!await _authservice.ValidateUser(userEmail, password))
        {
            response.AddError("Username or Password Invalid");
            return BadRequest(response);
        }

        response.Data = await _authservice.CreateToken();
        return Ok(response);
    }

    [HttpPost("CheckEmail")]
    public async Task<IActionResult> CheckEmail(string userEmail)
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
}