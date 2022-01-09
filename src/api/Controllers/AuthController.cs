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
        if (!await _authservice.ValidateUser(userEmail, password))
        {
            return BadRequest();
        }
        return Ok(new {Token = await _authservice.CreateToken()});
    }
}