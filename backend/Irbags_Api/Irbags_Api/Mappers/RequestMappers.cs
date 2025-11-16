using Irbags_Api.AuthController.Models.Request;
using AppReq = Irbags.Application.Models.Request.LoginRequest;

namespace Irbags_Api.Mappers
{
    public static class RequestMappers
    {
        public static AppReq ToApplicationLoginRequest(this LoginRequest src)
        {
            if (src is null) return null!;
            return new AppReq
            {
                Login = src.Login,
                Password = src.Password
            };
        }
    }
}