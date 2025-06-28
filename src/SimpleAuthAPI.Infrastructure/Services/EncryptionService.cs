using System;
using BCrypt.Net;
using SimpleAuthAPI.Application.Abstractions.Interfaces;

namespace SimpleAuthAPI.Infrastructure.Services;

public class EncryptionService : IEncryptionService
{
  public string HashText(string text) => BCrypt.Net.BCrypt.HashPassword(text);

  public bool VerifyHash(string text, string hashedText)
  {
    return BCrypt.Net.BCrypt.Verify(text, hashedText);
  }
}
