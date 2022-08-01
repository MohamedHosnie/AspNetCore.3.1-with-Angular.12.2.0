
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Users
{
    public interface IUserAppService
    {
        public Task<bool> UsernameIsUnique(string username);
    }
}
