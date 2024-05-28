using Data.Model;
using System.Threading.Tasks;

namespace Data.DataAccess.Security
{
    public interface IAuthenticateService
    {
        Task<AuthUser> AuthenticateAsync(string userName, string password);
    }
}
