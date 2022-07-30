using ElectronicsShop.Mvc.Models;

namespace ElectronicsShop.Mvc.Shared
{
    public interface ISession
    {
        public User LoggedInUser { get; set; }
    }
}
