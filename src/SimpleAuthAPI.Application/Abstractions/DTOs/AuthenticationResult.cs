namespace SimpleAuthAPI.Application.Abstractions.DTOs;

public record class AuthenticationResult(bool Success,
                                         string Email,
                                         string Token,
                                         string RefreshToken);
