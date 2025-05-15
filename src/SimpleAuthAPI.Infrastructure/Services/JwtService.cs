using System;
using SimpleAuthAPI.Application.Abstractions.Interfaces;

namespace SimpleAuthAPI.Infrastructure.Services;

public class JwtService : IJwtService
{
  public string GenerateToken()
  {
    throw new NotImplementedException();
  }

  public bool ValidateToken(string Token)
  {
    throw new NotImplementedException();
  }
}
