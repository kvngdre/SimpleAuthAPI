using System;
using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.Application.Abstractions.Interfaces;

public interface IUserService
{
  Task<Result<List<UserResponse>>> GetAllUsersAsync();
}
