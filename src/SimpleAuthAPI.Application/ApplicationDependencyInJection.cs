using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Application.Services.Authentication;

namespace SimpleAuthAPI.Application;

public static class ApplicationDependencyInJection
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddScoped<IAuthService, AuthService>();

    return services;
  }
}
