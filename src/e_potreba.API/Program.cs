using e_potreba.Infrastructure.DatabaseContext;
using e_potreba.Infrastructure.ServiceExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DatabaseConfigure(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<MsSqlDatabaseContext>();
dataContext?.Database.Migrate();


app.MapControllers();

app.Run();