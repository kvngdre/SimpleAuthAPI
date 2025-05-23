using System;
using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.Application.Abstractions.Interfaces;

public interface IUserService
{
  Task<Result<List<UserResult>>> GetAllUsersAsync();
  Task<Result<UserResult>> GetUserAsync(Guid userId);
}
