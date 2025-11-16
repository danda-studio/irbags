using Irbags.Application;
using Irbags.Application.Store;
using Irbags.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

// Конфигурация
var configuration = builder.Configuration;


string connectionString;
var host = Environment.GetEnvironmentVariable("Host");
var port = Environment.GetEnvironmentVariable("Port");
var database = Environment.GetEnvironmentVariable("Database");
var username = Environment.GetEnvironmentVariable("Username");
var password = Environment.GetEnvironmentVariable("Password");

if (!string.IsNullOrEmpty(host))
{
    connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";
}
else
{
    connectionString = configuration.GetConnectionString("DefaultConnection")
        ?? throw new Exception("Не найдена строка подключения");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString,
    b => b.MigrationsAssembly("Irbags.Infrastructure")));

// Регистрация сервисов приложения/инфраструктуры
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapScalarApiReference(options =>
    {
        options.OpenApiRoutePattern = "/swagger/v1/swagger.json";
        options.Title = "Irbags API Documentation";
    });

    app.MapGet("/", context =>
    {
        context.Response.Redirect("/scalar");
        return Task.CompletedTask;
    });
}
else
{
    app.MapGet("/", () => "Irbags API is running");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
