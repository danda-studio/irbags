using Irbags.Application.Models.Request;
using Irbags.Application.Models.Response;

namespace Irbags.Application
{
    public interface IAuthService
    {
        public Task<LoginResponse> GetUser(LoginRequest loginRequest);
        public Task<GetRefreshTokenResponse> GetRefreshToken(string refreshToken);
        public Task<bool> LogoutUser(string refreshToken);
    }
}
