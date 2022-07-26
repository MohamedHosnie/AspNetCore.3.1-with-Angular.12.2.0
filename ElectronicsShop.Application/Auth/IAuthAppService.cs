using ElectronicsShop.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Auth
{
    public interface IAuthAppService
    {
        public Task<int> CreateUser(User user, string password);
        public Task<User> ValidateUser(User user, string password);
        public Task<string> CreateJwtToken(User user);

        public Task<int?> GetLoggedInUserId();

        public Task<User> GetLoggedInUser();
    }
}
