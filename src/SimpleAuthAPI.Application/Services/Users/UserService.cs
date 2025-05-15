using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Domain.Entities;
using SimpleAuthAPI.Domain.Errors;
using SimpleAuthAPI.Domain.Repositories;
using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.Application.Services.Users;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;

  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<Result<List<UserResult>>> GetAllUsersAsync()
  {
    IEnumerable<User> users = await _userRepository.FindAllUsersAsync();

    List<UserResult> userResults = [.. users.Select(u => new UserResult(u.Id, u.Email, u.CreatedAt, u.LastLoginAt))];

    return Result.Success("Fetched all users successfully", userResults);
  }

  public async Task<Result<UserResult>> GetUserAsync(Guid userId)
  {
    User? user = await _userRepository.FindUserByIdAsync(userId);

    if (user is null)
    {
      return Result.Failure<UserResult>(DomainErrors.UserErrors.UserNotFound);
    }

    UserResult userResult = new(user.Id, user.Email, user.CreatedAt, user.LastLoginAt);

    return Result.Success("User fetched successfully", userResult);
  }
}