namespace SimpleAuthAPI.Application.Abstractions.Interfaces;

public interface IEncryptionService
{
  string HashText(string text);
  bool VerifyHash(string text, string hashedText);
}
