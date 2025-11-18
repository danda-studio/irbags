using Irbags.Application;
using Irbags.Application.Models.Response;
using Irbags.Application.Store;
using Irbags.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

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


var jwtOptions = configuration.GetSection("Jwt")
                              .Get<JwtSettings>() ?? new JwtSettings();

builder.Services.AddSingleton(jwtOptions);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        byte[] signingKeyBytes = Encoding.UTF8
            .GetBytes(jwtOptions.Key);

        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString,
    b => b.MigrationsAssembly("Irbags.Infrastructure")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

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
