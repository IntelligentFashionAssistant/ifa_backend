using api;
using domain.Entitys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using persistence;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
               options => options.UseSqlServer("Server=SCS\\SQLEXPRESS;Database=IFA;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddIdentityCore<User>(
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
               
               }
                )
               .AddRoles<IdentityRole<long>>()
               .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(new StaticFileOptions
{
    // FileProvider = new PhysicalFileProvider("c:\\Images"),
    FileProvider = new PhysicalFileProvider("/home/moamen/temp/"),

    RequestPath = "/StaticFiles"
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();