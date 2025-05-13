using System;
using SimpleAuthAPI.Application.DTOs;

namespace SimpleAuthAPI.Application.Interfaces;

public interface IAuthService
{
  Task<AuthenticationResult> RegisterAsync(RegisterRequest request);
  Task<AuthenticationResult> LoginAsync(LoginRequest request);
  Task<bool> ValidateTokenAsync(string token);
}
