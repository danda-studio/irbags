using Irbags.Application.Auth.Models.Request;
using Irbags.Application.Auth.Models.Response;

namespace Irbags.Application.Auth
{
    public interface IAuthService
    {
        public Task<LoginResponse> GetUser(LoginRequest loginRequest);
        public Task<GetRefreshTokenResponse> GetRefreshToken(string refreshToken);
        public Task<bool> LogoutUser(string refreshToken);
    }
}
