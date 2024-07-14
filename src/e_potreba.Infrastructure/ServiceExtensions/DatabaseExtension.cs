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

        services.AddDbContext<MsSqlDatabaseContext>(opt => opt.UseSqlServer(connectionString));
    }
    public static void DatabaseMigrate(
        this IServiceScope serviceScope
        )
    {
        var dataContext = serviceScope.ServiceProvider.GetService<MsSqlDatabaseContext>();
        dataContext?.Database.Migrate();
    }

}
