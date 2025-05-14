using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Domain.Entities;
using SimpleAuthAPI.Domain.Errors;
using SimpleAuthAPI.Domain.Repositories;
using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.Application.Services.Authentication;

public class AuthService : IAuthService
{
  private readonly IUserRepository _userRepository;
  private readonly IEncryptionService _encryptionService;

  public AuthService(IUserRepository userRepository, IEncryptionService encryptionService)
  {
    _userRepository = userRepository;
    _encryptionService = encryptionService;
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

    return Result.Success(new AuthenticationResult(user.Id, request.Email, "accessToken", "refreshToken"));

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
