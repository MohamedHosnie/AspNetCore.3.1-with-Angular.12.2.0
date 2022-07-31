using ElectronicsShop.Domain.Repositories;

namespace ElectronicsShop.Application.Users
{
    public class UserAppService : ElectronicsShopAppServiceBase, IUserAppService
    {
        public readonly IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool UsernameIsUnique(string username)
        {
            var existingUser = _userRepository.GetByUsername(username);
            
            return existingUser == null;
        }
    }
}
