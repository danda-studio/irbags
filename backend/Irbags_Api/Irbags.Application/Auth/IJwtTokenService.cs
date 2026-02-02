using Irbags.Application.Auth.Models.Response;

namespace Irbags.Application.Auth
{
    public interface IJwtTokenService
    {
        public string GenerateAccessToken(UserModel user);
        public string GenerateRefreshToken();
    }
}
