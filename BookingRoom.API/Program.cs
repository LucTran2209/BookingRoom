
using BookingRoom.Application.DependencyInjection.Extentions;
using BookingRoom.Infastructure.DependencyInjection.Extentions;
using BookingRoom.Persistence.DependencyInjection.Extentions;
using BookingRoom.Persistence.DependencyInjection.Options;

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
            builder.Services.AddSwaggerGen();
            //====================================

            // # PERSISTENCE LAYER
            builder.Services.ConfigureSqlServerOptionsPersistence(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
            builder.Services.AddSqlServerPersistence();

            // # APPLICATION LAYER
            builder.Services.AddAutoMapperProfiles();
            builder.Services.AddDIService();

            // # INFASTRUCTURE LAYER
            builder.Services.AddServiceInfastructure(builder.Configuration);

            var app = builder.Build();

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