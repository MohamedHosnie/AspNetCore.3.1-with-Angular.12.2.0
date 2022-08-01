using ElectronicsShop.Domain.Users;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Auth
{
    public interface IAuthAppService
    {
        Task<int> CreateUser(User user, string password);
        Task<User> ValidateUser(string username, string password);
        Task<string> CreateJwtToken(User user);
        Task<User> GetLoggedInUser();
    }
}
