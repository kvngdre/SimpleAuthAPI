using System;
using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.API.Shared;

public class ApiResponse<TValue>
{
  public bool Success { get; set; }
  public string? Message { get; set; }
  public TValue? Value { get; set; }
  public Error? Error { get; set; }

  public static ApiResponse<TValue> CreateSuccess(TValue value, string message)
      => new() { Success = true, Message = message, Value = value };

  public static ApiResponse<TValue> CreateFailure(Error error)
      => new() { Success = false, Error = error };
}
