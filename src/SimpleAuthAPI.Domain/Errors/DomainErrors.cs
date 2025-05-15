using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.Domain.Errors;


public static class DomainErrors
{
  public static class AuthenticationErrors
  {
    public static readonly Error InvalidUsername = new(
      "Email.Invalid",
      "Email address format is invalid");

    public static readonly Error InvalidCredentials = new(
      "Authentication.InvalidCredentials",
      "Invalid email or password");
  }

  public static class UserErrors
  {
    public static readonly Error DuplicateEmail = new(
      "Email.DuplicateEmail",
      "The provided email address already exists");


  }
}