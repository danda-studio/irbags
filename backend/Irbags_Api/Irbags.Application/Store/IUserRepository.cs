using Irabags.Core.User;

namespace Irbags.Application.Store
{
    public interface IUserRepository
    {
        public Task<User> GetUser();
    }
}
