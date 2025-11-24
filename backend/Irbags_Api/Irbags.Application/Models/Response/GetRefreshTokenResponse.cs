
namespace Irbags.Application.Models.Response
{
    public class GetRefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
    }
}
