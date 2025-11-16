
using Irbags.Application.Models.Request;
using Irbags.Application.Models.Response;
using Irbags.Application.Store;

namespace Irbags.Application
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<LoginResponse> GetUser(LoginRequest loginRequest)
        {
            return null;
        }

        public Task<GetRefreshTokenResponse> GetRefreshToken()
        {
            return null;
        }

        public Task<bool> LogoutUser()
        {
            return null;
        }

    }
}
