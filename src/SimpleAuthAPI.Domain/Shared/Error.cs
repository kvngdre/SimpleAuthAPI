namespace SimpleAuthAPI.Domain.Shared;

public class Error(string code, string description) : IEquatable<Error>
{
  public string Code { get; } = code;
  public string Description { get; } = description;

  public bool Equals(Error? other)
  {
    if (other is null) return false;

    return Code == other.Code && Description == other.Description;
  }

  public static Error None => new(String.Empty, String.Empty);

  public override bool Equals(object? obj) => obj is Error error && Equals(error);

  public override int GetHashCode() => HashCode.Combine(Code, Description);

  public static bool operator ==(Error? left, Error? right)
  {
    if (left is null && right is null) return true;

    if (left is null || right is null) return false;

    if (ReferenceEquals(left, right)) return true;

    return left.Equals(right);
  }

  public static bool operator !=(Error? right, Error? left) => !(left == right);
}