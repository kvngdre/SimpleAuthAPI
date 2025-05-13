using System;
using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.Application.Abstractions.Interfaces;

public interface IAuthService
{
  Task<Result<AuthenticationResult>> RegisterAsync(RegisterRequest request);
  Task<AuthenticationResult> LoginAsync(LoginRequest request);
  Task<bool> ValidateTokenAsync(string token);
}
