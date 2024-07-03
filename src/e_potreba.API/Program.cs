using e_potreba.Infrastructure.DatabaseContext;
using e_potreba.Infrastructure.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DatabaseConfigure(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<MsSqlDatabaseContext>();
dataContext?.Database.EnsureCreated();

app.MapControllers();

app.Run();