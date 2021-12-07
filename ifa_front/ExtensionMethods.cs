using application.persistence;
using application.services;
using Microsoft.Extensions.DependencyInjection;
using persistence.Repositories;

namespace ifa_front
{
    public static class ExtensionMethods
    {
        public static void AddServices(this IServiceCollection services)
        {
            //Repository

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGarmentRepository, GarmentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();

            //Service
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGarmentService, GarmentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IPropertyService, PropertyService>();

        }
    }
}
