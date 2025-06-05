using AdminSisters.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.AddDependencyInjection();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
