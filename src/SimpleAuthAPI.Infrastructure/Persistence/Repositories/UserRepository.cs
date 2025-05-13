using SimpleAuthAPI.Domain.Entities;
using SimpleAuthAPI.Domain.Repositories;

namespace SimpleAuthAPI.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
  public Task DeleteUserAsync(User user)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EmailAlreadyExistsAsync(string email)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<User>> FindAllUsersAsync()
  {
    throw new NotImplementedException();
  }

  public Task<User?> FindUserByEmailAsync(string email)
  {
    throw new NotImplementedException();
  }

  public Task<User?> FindUserByIdAsync(Guid userid)
  {
    throw new NotImplementedException();
  }

  public Task<User> InsertUserAsync(User user)
  {
    throw new NotImplementedException();
  }

  public Task<User> UpdateUserAsync(User user)
  {
    throw new NotImplementedException();
  }
}
