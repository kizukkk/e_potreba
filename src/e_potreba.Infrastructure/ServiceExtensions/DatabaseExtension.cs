using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using e_potreba.Infrastructure.DatabaseContext;
using Microsoft.Data.SqlClient;
using Polly.Retry;
using Polly;

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

        services.AddDbContext<MsSqlDatabaseContext>(opt => opt.UseSqlServer(connectionString));
    }

    public static void DatabaseMigrate(
        this IServiceScope serviceScope
        )
    {
        ResiliencePipeline pipeline = new ResiliencePipelineBuilder()
            .AddRetry(new RetryStrategyOptions
            {
                ShouldHandle = args => args.Outcome switch
                {
                    {Exception: SqlException } => PredicateResult.True(),
                    _ => PredicateResult.False(),
                },
                MaxRetryAttempts = 2,
                OnRetry = retryArgumets =>
                {
                    Console.WriteLine($"Current attemp: {retryArgumets.AttemptNumber}, {retryArgumets.Outcome.Exception}");
                    return ValueTask.CompletedTask;
                }
            })
            .AddTimeout(TimeSpan.FromSeconds(3))
            .Build();

        var dataContext = serviceScope.ServiceProvider.GetService<MsSqlDatabaseContext>();
        pipeline.Execute(() => dataContext?.Database.Migrate());
    }

}
