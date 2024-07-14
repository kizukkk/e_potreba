using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using e_potreba.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace e_potreba.Infrastructure.ServiceExtensions;
public static class DatabaseExtension
{
    public static void DatabaseConfig(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        var targetDatabase = configuration.GetSection("TargetDatabase").Value;
        var connectionString = configuration.GetConnectionString(targetDatabase);

        services.AddDbContext<MsSqlDatabaseContext>(opt =>
        {
            opt.UseSqlServer(
                connectionString,
                sqlServerOptionsAction: sqlOptitons =>
                {
                    sqlOptitons.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(15),
                        errorNumbersToAdd: null
                        );
                }).LogTo(
                    filter:(eventId, level) => eventId.Id == CoreEventId.ExecutionStrategyRetrying,
                    logger: (eventData) =>
                    {
                        var retryEventData = eventData as ExecutionStrategyEventData;
                        var exceptions = retryEventData!.ExceptionsEncountered;
                        Console.WriteLine($"Retry #{exceptions.Count} with delay {retryEventData.Delay} due to error: {exceptions.Last().Message}");
                    }
            );
        });
    }
    public static void DatabaseMigrate(
        this IServiceScope serviceScope
        )
    {
        var dataContext = serviceScope.ServiceProvider.GetService<MsSqlDatabaseContext>();
        dataContext?.Database.Migrate();
    }

}
