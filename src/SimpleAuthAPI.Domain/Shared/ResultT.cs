namespace SimpleAuthAPI.Domain.Shared;

public class Result<TValue> : Result
{
  private readonly TValue? _value;

  protected internal Result(TValue? value, bool isSuccess)
    : base(isSuccess, Error.None)
  {
    _value = value;
  }

  public TValue Value => IsSuccess
      ? _value!
      : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

}
