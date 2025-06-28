using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("me")]
        public async Task GetAuthenticatedUser()
        {
            HttpContext context = HttpContext;
            context.Items.TryGetValue("AuthenticatedUser", out dynamic? user);
            var u = context.User;
            Console.WriteLine(u.Claims);
            foreach (var item in u.Claims)
            {
                System.Console.WriteLine(item);
            }


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            await context.Response.WriteAsJsonAsync(new { userId = "user!.UserId", email = "user.Email" });
        }
    }
}
