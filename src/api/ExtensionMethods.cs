using application.persistence;
using application.services;
using Microsoft.Extensions.DependencyInjection;
using persistence.Repositories;

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
            services.AddScoped<IPropertyRepository, PropertyRepository>();//
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IShapeRepository, ShapeRepository>();
            services.AddScoped<IBodySizesRepository, BodySizesRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            //Repository
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGarmentService, GarmentService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IImageService, ImageService>();



        }
    }
}
