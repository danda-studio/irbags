using Irbags.Application;
using Irbags_Api.AuthController.Models.Request;
using Irbags_Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Irbags_Api.AuthController
{
    [ApiController]
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
            var refreshToken = HttpContext.Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized("Refresh-токен отсутствует.");
            }

            var token = await _authService.GetRefreshToken(refreshToken);
            Response.Cookies.Append("refreshToken", token.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(7)
            });
            return Ok(new
            {
                accessToken = token.AccessToken,
                userId = token.UserId,
            });

        }

        // 2. Авторизация пользователя
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
        {
            var result = await _authService.GetUser(request.ToApplicationLoginRequest());

            Response.Cookies.Append("refreshToken", result.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(7)
            });
            return Ok(new 
            {
                accessToken = result.AccessToken,
                userId = result.UserId,
            });
        }

        // 3. Выход пользователя
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutUser()
        {
            var refreshToken = HttpContext.Request.Cookies["refreshToken"];

            // Если токена нет — считаем операцию выполненной (идемпотентно)
            if (string.IsNullOrEmpty(refreshToken))
            {
                Response.Cookies.Delete("refreshToken", new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Path = "/"
                });
                return NoContent();
            }

            var success = await _authService.LogoutUser(refreshToken);

            // Удаляем cookie в любом случае (безопасность / очистка на клиенте)
            Response.Cookies.Delete("refreshToken", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Path = "/"
            });

            if (success)
                return NoContent();

            return StatusCode(500, "Logout failed");
        }
    }
}
