using System;
using SimpleAuthAPI.Application.DTOs;
using SimpleAuthAPI.Application.Interfaces;
using SimpleAuthAPI.Domain.Repositories;

namespace SimpleAuthAPI.Application.Services.Authentication;

public class AuthService : IAuthService
{
  private readonly IUserRepository _userRepository;

  public AuthService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }


  public async Task<AuthenticationResult> RegisterAsync(RegisterRequest request)
  {
    // if (await _userRepository.EmailAlreadyExistsAsync(request.Email))
    // {
    //   return 
    // }

    throw new NotImplementedException();

  }

  public Task<AuthenticationResult> LoginAsync(LoginRequest request)
  {
    throw new NotImplementedException();
  }

  public Task<bool> ValidateTokenAsync(string token)
  {
    throw new NotImplementedException();
  }
}
