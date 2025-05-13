using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.Domain.Errors;


public static class DomainErrors
{
  public static class AuthErrors
  {
    public static readonly Error InvalidUsername = new(
      "Email.Invalid",
      "The provided email is not valid");
  }

  public static class UserErrors
  {
    public static readonly Error DuplicateEmail = new(
      "Email.DuplicateEmail",
      "The provided email address already exists");
  }
}