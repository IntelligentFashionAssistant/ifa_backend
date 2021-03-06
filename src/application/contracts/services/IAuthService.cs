namespace application.services;

public interface IAuthService
{
    Task<bool> ValidateUser(string userEmail, string userPassword);
    Task<string> CreateToken();
    Task<bool> EmailIsExist(string userEmail);

    Task<string> ConfirmEmailAsync(string userId, string token);
}