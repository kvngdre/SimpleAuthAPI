namespace SimpleAuthAPI.Application.Abstractions.DTOs;

public record class AuthenticationResult(Guid Id,
                                         string Email,
                                         string? Token = null);
