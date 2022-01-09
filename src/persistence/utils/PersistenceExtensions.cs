using System.Text;
using application.persistence;
using application.services;
using domain.Entitys;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using repository.Repositories;

namespace persistence.Repositories;

public static class PersistenceExtensions
{
    public static void AddApplicationDbContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<AppDbContext>(
            // options => options.UseSqlServer("Server=SCS\\SQLEXPRESS;Database=IFA;Trusted_Connection=True;MultipleActiveResultSets=true")
            options => options.UseSqlServer("Server=localhost,1433;Database=IFA2;User ID=SA;Password=Aamm-1970")
        );
    }


    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentityCore<User>(
                options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    // Password settings.
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = false;
                }).AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigureJWT(
        this IServiceCollection services
        // ,IConfiguration configuration
        )
    {
        // var jwtSettings = configuration.GetSection("JwtSettings");
        // var secretKey = Environment.GetEnvironmentVariable("SECRET");
        var secretKey = "mysupersecretkey"; // todo add key
        services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    // ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    // ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new
                        SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IGarmentRepository, GarmentRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>(); //
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IShapeRepository, ShapeRepository>();
        services.AddScoped<IBodySizesRepository, BodySizesRepository>();
        services.AddScoped<ISizeRepository, SizeRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IStoreFeedbackRepository, StoreFeedbackRepository>();
    }
}