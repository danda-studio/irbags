

namespace Irbags.Application.Models.Response
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public UserModel User { get; set; }
    }
}
