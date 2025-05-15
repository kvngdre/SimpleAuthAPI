using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Domain.Repositories;
using SimpleAuthAPI.Infrastructure.Persistence.Database;
using SimpleAuthAPI.Infrastructure.Persistence.Repositories;
using SimpleAuthAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SimpleAuthAPI.Application.Abstractions.Settings;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SimpleAuthAPI.Infrastructure;

public static class InfrastructureDependencyInjection
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configurationManager)
  {
    services.AddAuth(configurationManager);

    services.AddScoped<ApplicationDbContext>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddSingleton<IEncryptionService, EncryptionService>();

    return services;
  }

  public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configurationManager)
  {
    services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
    var jwtSettings = configurationManager.GetSection(JwtSettings.SectionName).Get<JwtSettings>()!;
    services.AddSingleton<IJwtService, JwtService>();

    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
              options.TokenValidationParameters = new TokenValidationParameters()
              {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                          Encoding.UTF8.GetBytes(jwtSettings.Secret)
                      )

              };
            });

    return services;
  }
}
