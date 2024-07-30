using BookingRoom.Persistence.DependencyInjection.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BookingRoom.Persistence.DependencyInjection.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddSqlServerPersistence(this IServiceCollection services)
        {
            services.AddDbContextPool<DbContext, ApplicationDbContext>((provider, buider) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var options = provider.GetRequiredService<IOptionsMonitor<SqlServerRetryOptions>>();

                #region
                buider
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
                .UseLazyLoadingProxies(false) // Tạm thời để false
                .UseSqlServer(
                    connectionString: configuration.GetConnectionString("SqlServerConnection"),
                    sqlServerOptionsAction: optionsBuider
                            => optionsBuider.ExecutionStrategy(
                                dependencies => new SqlServerRetryingExecutionStrategy(
                                    dependencies: dependencies,
                                    maxRetryCount: options.CurrentValue.MaxRetryCount,
                                    maxRetryDelay: options.CurrentValue.MaxRetryDelay,
                                    errorNumbersToAdd: options.CurrentValue.ErrorNumbersToAdd))
                            .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name))

                .AddInterceptors();
                #endregion  
            });
        }

        public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerOptionsPersistence(this IServiceCollection services, IConfiguration section)
        {
            return services.AddOptions<SqlServerRetryOptions>()
                            .Bind(section)
                            .ValidateDataAnnotations()
                            .ValidateOnStart();
        }
    }
}
