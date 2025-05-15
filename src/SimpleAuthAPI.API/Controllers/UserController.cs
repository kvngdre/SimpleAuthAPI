using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthAPI.API.Shared;
using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Application.Abstractions.Interfaces;
using SimpleAuthAPI.Domain.Shared;

namespace SimpleAuthAPI.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class User : ControllerBase
    {
        private readonly IUserService _userService;

        public User(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();

            if (result.IsFailure) return BadRequest(ApiResponse<UserResult>.CreateFailure(result.Error));

            return Ok(ApiResponse<List<UserResult>>.CreateSuccess(result.Value, result.Message));
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetAuthenticatedUser()
        {
            dynamic authenticatedUser = HttpContext.Items["AuthenticatedUser"]!;

            if (Guid.TryParse(authenticatedUser.UserId.ToString(), out Guid userId))
            {
                var result = await _userService.GetUserAsync(userId);

                if (result.IsFailure)
                    return BadRequest(ApiResponse<UserResult>.CreateFailure(result.Error));

                return Ok(ApiResponse<UserResult>.CreateSuccess(result.Value, result.Message));
            }

            return BadRequest(ApiResponse<UserResult>.CreateFailure(new Error("User.InvalidId", "Invalid user ID")));

        }
    }
}
