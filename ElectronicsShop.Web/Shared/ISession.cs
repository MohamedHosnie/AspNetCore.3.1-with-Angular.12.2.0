using ElectronicsShop.Web.Models;

namespace ElectronicsShop.Web.Shared
{
    public interface ISession
    {
        public User LoggedInUser { get; set; }
    }
}
