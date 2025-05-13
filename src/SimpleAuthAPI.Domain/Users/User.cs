using System;

namespace SimpleAuthAPI.Domain.Users;

public class User
{
  public Guid Id { get; set; }
  public required string Email { get; set; }
  public required string PasswordHash { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? LastLoginAt { get; set; }
}
