using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Domain.Entities;
using SimpleAuthAPI.Domain.Errors;
using SimpleAuthAPI.Domain.Repositories;
using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IUserRepository _userRepository;
  private readonly IEncryptionService _encryptionService;
  public readonly IJwtService _jwtService;

  public AuthenticationService(IUserRepository userRepository,
                               IEncryptionService encryptionService,
                               IJwtService jwtService)
  {
    _userRepository = userRepository;
    _encryptionService = encryptionService;
    _jwtService = jwtService;
  }


  public async Task<Result<AuthenticationResult>> RegisterAsync(RegisterRequest request)
  {
    if (await _userRepository.EmailAlreadyExistsAsync(request.Email))
    {
      return Result.Failure<AuthenticationResult>(DomainErrors.UserErrors.DuplicateEmail);
    }

    User user = new()
    {
      Email = request.Email,
      PasswordHash = _encryptionService.HashText(request.Password)
    };

    await _userRepository.InsertUserAsync(user);

    return Result.Success("Registration successful",
                          new AuthenticationResult(user.Id, request.Email));

  }

  public async Task<Result<AuthenticationResult>> LoginAsync(LoginRequest request)
  {
    User? user = await _userRepository.FindUserByEmailAsync(request.Email);

    if (user is null)
    {
      return Result.Failure<AuthenticationResult>(
          DomainErrors.AuthenticationErrors.InvalidCredentials);
    }

    if (!_encryptionService.VerifyHash(request.Password, user.PasswordHash))
    {
      return Result.Failure<AuthenticationResult>(DomainErrors.AuthenticationErrors.InvalidCredentials);
    }

    var token = _jwtService.GenerateToken(user);

    // Return successful result
    return Result.Success("Login successful",
      new AuthenticationResult(user.Id, user.Email, token));
  }

  public Task<bool> ValidateTokenAsync(string token)
  {
    throw new NotImplementedException();
  }
}
