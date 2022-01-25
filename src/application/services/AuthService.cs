using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
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

    public async Task<bool> EmailIsExist(string userEmail)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);

        if (user == null)
            return true;
        else
            throw new Exception("The email is already in use");
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes("mysupersecretkey"); 
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256); 
    }

    private async Task<List<Claim>> GetClaims()
    {
        var fullName = _user.FirstName + ' ' + _user.LastName;
        var claims = new List<Claim> {new Claim("email", _user.Email)};
        var roles = await _userManager.GetRolesAsync(_user);
        claims.Add(new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString()));
        claims.Add(new Claim("role", roles.First()));
        claims.Add(new Claim("FullName", fullName));
        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
        (
            claims: claims,
            expires: DateTime.Now.AddHours(5),
            signingCredentials: signingCredentials
        );
        return tokenOptions;
    }

    public async Task<string> ConfirmEmailAsync(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
             throw new NotImplementedException("User not found");

        var decodedToken = WebEncoders.Base64UrlDecode(token);
        string normalToken = Encoding.UTF8.GetString(decodedToken);

        var result = await _userManager.ConfirmEmailAsync(user, normalToken);

        if (result.Succeeded)
            return "Email confirmed successfully!";
               

         throw new NotImplementedException("Email did not confirm");
    }
}