namespace SimpleAuthAPI.Domain.Shared;

public class Result
{
  protected internal Result(bool isSuccess, Error error)
  {
    if (isSuccess && error != Error.None)
    {
      throw new InvalidOperationException();
    }

    if (!isSuccess && error == Error.None)
    {
      throw new InvalidOperationException();
    }

    IsSuccess = isSuccess;
    Error = error;
  }

  public bool IsSuccess { get; }
  public bool IsFailure => !IsSuccess;

  public Error Error { get; }

  public static Result<TValue> Success<TValue>(TValue value) => new(value, true);

  public static Result Failure(Error error) => new(false, error);
}
