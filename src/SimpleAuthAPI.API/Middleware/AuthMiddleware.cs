using System;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace SimpleAuthAPI.API.Middleware;

public class AuthMiddleware
{
  private readonly RequestDelegate _next;
  private readonly IJwtService _jwtService;

  public AuthMiddleware(RequestDelegate next, IJwtService jwtService)
  {
    _next = next;
    _jwtService = jwtService;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

    if (token != null)
    {
      try
      {
        if (!_jwtService.ValidateToken(token))
        {
          context.Response.StatusCode = 401;
          return;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        context.Items.Add("AuthenticatedUser", new
        {
          UserId = jwtToken.Claims.First(x => x.Type == "sub").Value,
          Email = jwtToken.Claims.First(x => x.Type == "email").Value
        });
      }
      catch
      {
        context.Response.StatusCode = 401;
        return;
      }
    }

    await _next(context);
  }
}
