using System;
using SimpleAuthAPI.Domain.Entities;

namespace SimpleAuthAPI.Application.Abstractions.Interfaces;

public interface IJwtService
{
  string GenerateToken(User user);
  bool ValidateToken(string token);
}
