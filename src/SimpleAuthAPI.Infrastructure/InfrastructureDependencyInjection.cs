using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleAuthAPI.Infrastructure.Persistence.Database;

namespace SimpleAuthAPI.Infrastructure;

public static class InfrastructureDependencyInjection
{
  public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
  {
    services.AddScoped<ApplicationDbContext>();

    return services;
  }
}
