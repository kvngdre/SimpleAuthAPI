using System;

namespace SimpleAuthAPI.Application.Abstractions.Interfaces;

public interface IJwtService
{
  string GenerateToken();
  bool ValidateToken(string Token)
}
