using e_potreba.Infrastructure.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DatabaseConfigure(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();