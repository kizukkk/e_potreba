using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using e_potreba.Infrastructure.DatabaseContext;

namespace e_potreba.Infrastructure.ServiceExtensions;
public static class DatabaseExtension
{
    public static void DatabaseConfigure(
        this IServiceCollection services, 
        IConfiguration configuration
        )
    {
        var targetDatabase = configuration.GetSection("TargetDatabase").Value;
        var connectionString = configuration.GetConnectionString(targetDatabase);

        services.AddDbContext<MsSqlDatabaseContext>(opt => opt.UseSqlServer(connectionString));
    }
}
