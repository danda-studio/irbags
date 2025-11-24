using Irbags.Application.Models.Request;
using Irbags.Application.Models.Response;
using Irbags.Application.Store;

namespace Irbags.Application
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtService;

        public AuthService(IUserRepository userRepository, IJwtTokenService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> GetUser(LoginRequest loginRequest)
        {
            if (loginRequest == null) 
                return null;

            var user = await _userRepository.GetUserByLogin(loginRequest.Login);
            if (user == null)
            {
                return new LoginResponse();
            }

            // Простейшая проверка пароля. В проде — хэш+salt.
            if (user.Password != loginRequest.Password)
            {
                return new LoginResponse();
            }

            var userModel = new UserModel
            {
                Id = user.Id,
                Login = user.Login
            };

            var accessToken = _jwtService.GenerateAccessToken(userModel);
            var refreshToken = _jwtService.GenerateRefreshToken();


            // Сохраняем refresh token
            await _userRepository.SaveRefreshToken(user, refreshToken);

            return new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserId = user.Id
            };
        }

        public async Task<GetRefreshTokenResponse> GetRefreshToken(string Token)
        {
            var user = await _userRepository.GetUserByRefresh(Token);
            if (user == null)
                return null;

            var userModel = new UserModel
            {
                Id = user.Id,
                Login = user.Login
            };

            var accessToken = _jwtService.GenerateAccessToken(userModel);
            var refreshToken = _jwtService.GenerateRefreshToken();

            await _userRepository.SaveRefreshToken(user, refreshToken);

            return new GetRefreshTokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserId = user.Id
            };

        }

        public async Task<bool> LogoutUser(string refreshToken)
        {
           await _userRepository.DeleteToken(refreshToken);
           return true;
        }
    }
}
