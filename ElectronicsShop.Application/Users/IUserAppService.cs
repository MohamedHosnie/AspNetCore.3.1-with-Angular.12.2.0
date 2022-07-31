
namespace ElectronicsShop.Application.Users
{
    public interface IUserAppService
    {
        public bool UsernameIsUnique(string username);
    }
}
