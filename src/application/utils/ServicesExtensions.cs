using System.Text;
using application.services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace application.utils;
public static class ServicesExtensions
{
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IGarmentService, GarmentService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IAuthService, AuthService>(); 
        services.AddScoped<IMailingService, MailingService>();
    }
}
