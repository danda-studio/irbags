namespace Irbags_Api.AuthController.Models.Response
{
    public class GetRefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public UserModel User { get; set; }
    }
}
