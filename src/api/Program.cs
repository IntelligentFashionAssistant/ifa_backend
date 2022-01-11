using api;
using application.utils;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Propertys.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationDbContext();
builder.Services.ConfigureIdentity();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "MyProject", Version = "v1.0.0"});

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        {securitySchema, new[] {"Bearer"}}
    };

    c.AddSecurityRequirement(securityRequirement);
});
// builder.Services.AddAuthentication();
builder.Services.ConfigureJWT();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
     FileProvider = new PhysicalFileProvider("c:\\Images"),
      //FileProvider = new PhysicalFileProvider("/home/moamen/temp/"),

    RequestPath = "/StaticFiles"
});
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();