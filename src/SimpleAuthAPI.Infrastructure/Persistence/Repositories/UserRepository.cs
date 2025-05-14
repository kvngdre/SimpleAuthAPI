using Microsoft.EntityFrameworkCore;
using SimpleAuthAPI.Domain.Entities;
using SimpleAuthAPI.Domain.Repositories;
using SimpleAuthAPI.Infrastructure.Persistence.Database;

namespace SimpleAuthAPI.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
  private readonly ApplicationDbContext _dbContext;

  public UserRepository(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task DeleteUserAsync(User user)
  {
    _dbContext.Users.Remove(user);
    await _dbContext.SaveChangesAsync();
  }

  public Task<bool> EmailAlreadyExistsAsync(string email)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<User>> FindAllUsersAsync()
  {
    return _dbContext.Users;
  }

  public Task<User?> FindUserByEmailAsync(string email)
  {
    return _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
  }

  public async Task<User?> FindUserByIdAsync(Guid userId)
  {
    return _dbContext.Users.Find(userId);
  }

  public async Task<User> InsertUserAsync(User user)
  {
    _dbContext.Users.Add(user);
    await _dbContext.SaveChangesAsync();

    return user;
  }

  public async Task<User> UpdateUserAsync(User user)
  {
    _dbContext.Users.Update(user);
    await _dbContext.SaveChangesAsync();

    return user;
  }
}
