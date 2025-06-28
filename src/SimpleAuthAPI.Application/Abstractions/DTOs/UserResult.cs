namespace SimpleAuthAPI.Application.Abstractions.DTOs;

public record class UserResult(Guid Id,
                                 string Email,
                                 DateTime CreatedAt,
                                 DateTime? LastLoginAt);