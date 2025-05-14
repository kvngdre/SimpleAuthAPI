namespace SimpleAuthAPI.Application.Abstractions.DTOs;

public record class UserResponse(Guid Id,
                                 string Email,
                                 DateTime CreatedAt,
                                 DateTime? LastLoginAt);