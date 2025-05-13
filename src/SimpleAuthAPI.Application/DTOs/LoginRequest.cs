using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI.Application.DTOs;

public class LoginRequest
{
  [Required]
  public string Email { get; set; } = String.Empty;

  [Required]
  public string Password { get; set; } = String.Empty;
}
