using Irabags.Core.User;
using Irbags.Application.Store;

namespace Irbags.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() 
        {
            
        }

        public Task<User> GetUser()
        {
            return null;
        }
    }
}
