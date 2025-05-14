namespace SimpleAuthAPI.Domain.Shared;

public class Result<TValue> : Result
{
  private readonly TValue? _value;

  protected internal Result(string message, TValue? value, bool isSuccess, Error error)
    : base(isSuccess, error, message)
  {
    _value = value;
  }

  public TValue Value => IsSuccess
      ? _value!
      : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

}
