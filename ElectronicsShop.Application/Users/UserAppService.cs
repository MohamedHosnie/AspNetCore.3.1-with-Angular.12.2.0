using System.Threading.Tasks;
using ElectronicsShop.Domain.Repositories;
using ElectronicsShop.Domain.Users;

namespace ElectronicsShop.Application.Users
{
    public class UserAppService : ElectronicsShopAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, int> _userRepository;
        public UserAppService(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> UsernameIsUnique(string username)
        {
            var existingUser = await _userRepository.GetSingleAsync(filter: user => user.Username == username);
            
            return existingUser == null;
        }
    }
}
