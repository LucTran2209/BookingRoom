using BookingRoom.Domain.Abstractions;
using BookingRoom.Infastructure.Common;
using BookingRoom.Infastructure.Repository;
using BookingRoom.Persistence.RepositoryInterface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingRoom.Infastructure.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServiceInfastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductRepository, ProductRepository>();

            //Building demo
            services.AddScoped<IBuildingRepository, BuildingRepository>();

            //Room demo
            services.AddScoped<IRoomRepository, RoomRepository>();

            // Add Authentication
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.RequireHttpsMetadata = false;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidAudience = configuration["JWT:ValidAudience"],
            //        ValidIssuer = configuration["JWT:ValidIssuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            //    };
            //});

            return services;
        }
    }
}
