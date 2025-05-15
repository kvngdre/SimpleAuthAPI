using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthAPI.API.Shared;
using SimpleAuthAPI.Application.Abstractions.DTOs;
using SimpleAuthAPI.Application.Abstractions.Interfaces;

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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();

            if (result.IsFailure) return BadRequest(ApiResponse<UserResult>.CreateFailure(result.Error));

            return Ok(ApiResponse<List<UserResult>>.CreateSuccess(result.Value, result.Message));
        }
    }
}
