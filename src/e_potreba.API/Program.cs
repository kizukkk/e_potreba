using e_potreba.Application.Repositories;
using e_potreba.Application.Service.AuthServices;
using e_potreba.Infrastructure.Repositories;
using e_potreba.Infrastructure.ServiceExtensions;
using e_potreba.Infrastructure.Policy;
using e_potreba.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Polly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DatabaseConfig(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<UserRegistryService>();

builder.Services.AddResiliencePipeline("default-pipeline", builder =>   
{
    builder.AddRetry(ResiliencePolicyOptions.RetryStrategy);
    builder.AddTimeout(ResiliencePolicyOptions.TimeoutStrategy);
    builder.Build();
});
var app = builder.Build();

DatabaseExtension.DatabaseMigrate(app.Services.CreateScope());

app.Lifetime.ApplicationStopped.Register(() =>
{
    Console.WriteLine("\nI'm shutdown...");
    var dataContext = app.Services.CreateScope().ServiceProvider.GetService<MsSqlDatabaseContext>();
    var tablse = dataContext!.Model.GetEntityTypes()
        .Select(t => t.GetTableName())
        .Distinct()
        .ToList();

    foreach (var t in tablse)
    {
        Console.WriteLine($"\tDroping rows in {t} table:");
        dataContext.Database.ExecuteSqlRaw($"TRUNCATE TABLE {t}");
    }
});


//Temp error handler
app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch
    {
        context.Response.StatusCode = 500;
    }
});

app.MapControllers();

app.Run();