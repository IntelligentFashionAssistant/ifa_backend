using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace application.services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    private User _user;
    
    public AuthService(UserManager<User> userManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    public async Task<bool> ValidateUser(string userEmail, string password)
    {
        _user = await _userManager.FindByEmailAsync(userEmail);
        return (_user != null && await _userManager.CheckPasswordAsync(_user, password));
    }


    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }


    private SigningCredentials GetSigningCredentials()
    {
        // var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
        var key = Encoding.UTF8.GetBytes("mysupersecretkey"); // todo configure key
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256); // algorithm
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim> {new Claim("email", _user.Email)};
        //claims.Add(new Claim("id", _user.Id.ToString()));
        claims.Add(new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()));
        var roles = await _userManager.GetRolesAsync(_user);
        claims.Add(new Claim("role", roles.First()));
        // foreach (var role in roles)
        // {
        //     claims.Add(new Claim("role", role));
        // }
        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        // var jwtSettings = _configuration.GetSection("JwtSettings");
        var tokenOptions = new JwtSecurityToken
        (
            // issuer: jwtSettings.GetSection("validIssuer").Value,
            // audience: jwtSettings.GetSection("validAudience").Value,
            claims: claims,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: signingCredentials
        );
        return tokenOptions;
    }
}