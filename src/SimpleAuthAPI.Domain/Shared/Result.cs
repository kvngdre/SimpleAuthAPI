namespace SimpleAuthAPI.Domain.Shared;

public class Result
{
  protected internal Result(bool isSuccess, Error error, string message)
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
    Message = message;
  }

  public bool IsSuccess { get; }
  public bool IsFailure => !IsSuccess;
  public Error Error { get; }
  public string Message { get; }

  public static Result Success(string message) => new(true, Error.None, message);

  public static Result<TValue> Success<TValue>(string message, TValue value) => new(message, value, true, Error.None);

  public static Result Failure(Error error) => new(false, error, String.Empty);

  public static Result<TValue> Failure<TValue>(Error error) => new(String.Empty, default, false, error);
}
