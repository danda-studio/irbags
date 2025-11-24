
namespace Irbags.Core.User
{
    public class Token
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
    }
}
