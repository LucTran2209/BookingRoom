using BookingRoom.Application.Abstraction.ServiceInterfaces;
using BookingRoom.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookingRoom.Application.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }

        public static IServiceCollection AddDIService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRoleService, RoleService>();
            return services;
        }
    }
}
