using System;

namespace SimpleAuthAPI.Domain.Users;

public interface IUserRepository
{
  Task<User?> FindUserByIdAsync(Guid userid);
  Task<IEnumerable<User>> FindAllUsersAsync();
  Task<User> InsertUserAsync(User user);
  Task<User> UpdateUserAsync(User user);
  Task DeleteUserAsync(User user);
  Task<User?> FindUserByEmailAsync(string email);
  Task<bool> EmailAlreadyExistsAsync(string email);
}
