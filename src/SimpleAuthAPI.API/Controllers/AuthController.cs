using Microsoft.AspNetCore.Mvc;
using SimpleAuthAPI.API.Shared;
using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Application.Abstractions.Interfaces;

namespace SimpleAuthAPI.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            if (result.IsFailure) return BadRequest(ApiResponse<AuthenticationResult>.CreateFailure(result.Error));

            return StatusCode(201, ApiResponse<AuthenticationResult>.CreateSuccess(result.Value, result.Message));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);

            if (result.IsFailure) return BadRequest(ApiResponse<AuthenticationResult>.CreateFailure(result.Error));

            return Ok(ApiResponse<AuthenticationResult>.CreateSuccess(result.Value, result.Message));
        }
    }
}
