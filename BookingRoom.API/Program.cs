
using BookingRoom.Application.DependencyInjection.Extentions;
using BookingRoom.Application.DependencyInjection.Options;
using BookingRoom.Infastructure.DependencyInjection.Extentions;
using BookingRoom.Persistence.DependencyInjection.Extentions;
using BookingRoom.Persistence.DependencyInjection.Options;
using Microsoft.OpenApi.Models;

namespace BookingRoom.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("V1", new OpenApiInfo
                //{
                //    Version = "v1",
                //    Title = "Demo_JWT",
                //    Description = "Product API"
                //});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {
                    new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                  }
                    },
                         new List < string > ()
                  }
                });
            });
            //====================================

            // # PERSISTENCE LAYER
            builder.Services.ConfigureSqlServerOptionsPersistence(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
            builder.Services.AddSqlServerPersistence();

            // # APPLICATION LAYER
            builder.Services.AddAutoMapperProfiles();
            builder.Services.AddDIService();
            builder.Services.AddAuthenticationConfig(builder.Configuration.GetSection(nameof(JwtConfig)));

            // # INFASTRUCTURE LAYER
            builder.Services.AddServiceInfastructure(builder.Configuration);

            var app = builder.Build();

            // CORS
            app.UseCors
                (policy =>
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}