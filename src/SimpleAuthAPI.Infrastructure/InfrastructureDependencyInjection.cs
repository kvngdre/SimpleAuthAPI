using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Domain.Repositories;
using SimpleAuthAPI.Infrastructure.Persistence.Database;
using SimpleAuthAPI.Infrastructure.Persistence.Repositories;
using SimpleAuthAPI.Infrastructure.Services;

namespace SimpleAuthAPI.Infrastructure;

public static class InfrastructureDependencyInjection
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
  {
    services.AddScoped<ApplicationDbContext>();

    services.AddScoped<IUserRepository, UserRepository>();
    services.AddSingleton<IEncryptionService, EncryptionService>();

    return services;
  }
}
