using System;

namespace SimpleAuthAPI.Application.Abstractions.Interfaces;

public interface IJwtGenerator
{
  string GenerateToken();
}
