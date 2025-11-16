using Irbags.Application;
using Irbags_Api.AuthController.Models.Request;
using Irbags_Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Irbags_Api.AuthController
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("api/auth/")]
    public class AuthController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService userService)
        {
            _authService = userService;
        }

        // 1. Получение refresh-token 

        [HttpGet("refresh")]
        public async Task<IActionResult> GetRefreshToken()
        {
            var users = await _authService.GetRefreshToken();
            return Ok(users);
        }

        // 2. Авторизация пользователя
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
        {
            var appRequest = request.ToApplicationLoginRequest();
            var result = await _authService.GetUser(appRequest);
            return Ok(result);
        }

        // 3. Выход пользователя
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutUser()
        {
            var result = await _authService.LogoutUser();
            return Ok(result);
        }
    }
}
