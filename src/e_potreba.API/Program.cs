using e_potreba.Application.Repositories;
using e_potreba.Application.Service.AuthServices;
using e_potreba.Infrastructure.Repositories;
using e_potreba.Infrastructure.ServiceExtensions;
using e_potreba.Infrastructure.Policy;
using Polly;
using e_potreba.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DatabaseConfig(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserRegistryService>();

builder.Services.AddResiliencePipeline("default-pipeline", builder =>   
{
    builder.AddRetry(ResiliencePolicyOptions.RetryStrategy);
    builder.AddTimeout(ResiliencePolicyOptions.TimeoutStrategy);
    builder.Build();
});
var app = builder.Build();

DatabaseExtension.DatabaseMigrate(app.Services.CreateScope()); 

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