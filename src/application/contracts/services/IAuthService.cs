namespace application.services;

public interface IAuthService
{
    Task<bool> ValidateUser(string userEmail, string userPassword);
    Task<string> CreateToken();
}