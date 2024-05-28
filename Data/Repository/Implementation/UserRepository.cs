using Data.Model;
using Data.Repository.Interface;
using Review.API.DatabaseConfigurations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private ReviewProductDbContext _dbContext;
        public UserRepository(ReviewProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task AddUserAsync(User user)
        {
            if (user != null)
            {
                await _dbContext.User.AddAsync(user).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return Task.FromResult(_dbContext.User.AsEnumerable());
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            if (userId > 0)
            {
                return Task.FromResult(_dbContext.User.First(t => t.id == userId));
            }
            return null;
        }

        public Task<User> GetUserByUserNameAsync(string userName)
        {
            if (userName != null && userName.Length > 0 )
            {
                return Task.FromResult(_dbContext.User.First(t => t.userName == userName));
            }
            return null;
        }

        public Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password)
        {
            if (userName != null && userName.Length > 0)
            {
                return Task.FromResult(_dbContext.User.First(t => t.userName == userName && t.password == password));
            }
            return null;
        }

        public void UpdateUser(User user)
        {
            if (user != null && user.id > 0)
            {
                _dbContext.User.Update(user);
            }
        }
    }
}
