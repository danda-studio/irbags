using Irabags.Core.User;

namespace Irbags.Application.Store
{
    public interface IUserRepository
    {
        public Task<User> GetUserByLogin(string login);
        public Task<User> GetUserByRefresh(string refreshToken);
        public Task SaveRefreshToken(User user, string refreshToken);
        public Task DeleteToken(string refreshToken);
    }
}
