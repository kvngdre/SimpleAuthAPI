using System;
using Microsoft.Extensions.DependencyInjection;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Application.Services.Authentication;
using SimpleAuthAPI.Application.Services.Users;

namespace SimpleAuthAPI.Application;

public static class ApplicationDependencyInJection
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddScoped<IAuthenticationService, AuthenticationService>();
    services.AddScoped<IUserService, UserService>();

    return services;
  }
}
