using e_potreba.Infrastructure.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DatabaseConfig(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

DatabaseExtension.DatabaseMigrate(app.Services.CreateScope()); 


app.MapControllers();

app.Run();