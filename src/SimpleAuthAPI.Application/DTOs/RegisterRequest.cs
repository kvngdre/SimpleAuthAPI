using System.ComponentModel.DataAnnotations;

namespace SimpleAuthAPI.Application.DTOs;

public class RegisterRequest
{
  [Required]
  [EmailAddress]
  public string Email { get; set; } = String.Empty;

  [Required]
  [StringLength(100, MinimumLength = 8)]
  public string Password { get; set; } = String.Empty;

  [Compare("Password", ErrorMessage = "Passwords do not match")]
  public string ConfirmPassword { get; set; } = String.Empty;
}
