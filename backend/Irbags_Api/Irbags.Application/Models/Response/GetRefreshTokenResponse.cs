namespace Irbags.Application.Models.Response
{
    public class GetRefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public UserModel User { get; set; }
    }
}
