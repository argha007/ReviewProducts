using Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);

        Task<IEnumerable<User>> GetAllUsersAsync();

        Task AddUserAsync(User user);

        void UpdateUser(User user);

        Task<User> GetUserByUserNameAsync(string userName);

        Task<User> GetUserByUserNameAndPasswordAsync(string userName, string password);
    }
}
