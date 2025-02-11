using Microsoft.AspNetCore.Mvc;
using QuardIntel.DTOs;
using QuardIntel.Models;
using QuardIntel.Services;

namespace QuardIntel.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<User>>> Register([FromBody] RegisterUserRequest registerUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.Register(registerUserDto);
            if (user == null)
            {
                return BadRequest("User registration failed.");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<string>>> Login([FromBody] LoginUserRequest loginUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _userService.Login(loginUserDto.Username, loginUserDto.Password);
            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(token);
        }
    }
}
