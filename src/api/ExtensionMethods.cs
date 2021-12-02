using application.persistence;
using Microsoft.Extensions.DependencyInjection;
using repository.Repositories;

namespace api
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

        }
    }
}
