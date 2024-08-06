using BookingRoom.Application.Abstraction.ServiceInterface;
using BookingRoom.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IRoomService, RoomService>();
            return services;
        }
    }
}
