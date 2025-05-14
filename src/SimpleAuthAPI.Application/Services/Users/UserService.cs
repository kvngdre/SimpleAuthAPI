using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Domain.Entities;
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

  public async Task<Result<List<UserResponse>>> GetAllUsersAsync()
  {
    IEnumerable<User> users = await _userRepository.FindAllUsersAsync();

    List<UserResponse> userResponses = [.. users.Select(u => new UserResponse(u.Id, u.Email, u.CreatedAt, u.LastLoginAt))];

    return Result.Success(userResponses);
  }
}