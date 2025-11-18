using Irabags.Core.User;
using Irbags.Application.Store;
using Microsoft.EntityFrameworkCore;

namespace Irbags.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login);

            if (user == null)
            {
                return null;
            }
            return user; 
        }

        public async Task<User> GetUserByRefresh(string refreshToken)
        {
            var user = await _dbContext.Tokens
                .AsNoTracking()
                .Where(t => t.RefreshToken == refreshToken)
                .Select(t => t.User)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task SaveRefreshToken(User user, string refreshToken)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(refreshToken)) throw new ArgumentNullException(nameof(refreshToken));

            var existingToken = await _dbContext.Tokens
                .FirstOrDefaultAsync(t => t.UserId == user.Id);

            if(existingToken == null)
            {
                var token = new Token
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    RefreshToken = refreshToken,
                    CreatedAt = DateTime.UtcNow
                };
                _dbContext.Tokens.Add(token);
            }
            else
            {
                existingToken.CreatedAt = DateTime.UtcNow;
                existingToken.RefreshToken = refreshToken;
                _dbContext.Tokens.Update(existingToken);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteToken(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
                return;

            var token = await _dbContext.Tokens
                .FirstOrDefaultAsync(t => t.RefreshToken == refreshToken);

            if (token != null)
            {
                _dbContext.Tokens.Remove(token);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
