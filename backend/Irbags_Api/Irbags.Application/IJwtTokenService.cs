using Irbags.Application.Models.Response;

namespace Irbags.Application
{
    public interface IJwtTokenService
    {
        public string GenerateAccessToken(UserModel user);
        public string GenerateRefreshToken();
    }
}
