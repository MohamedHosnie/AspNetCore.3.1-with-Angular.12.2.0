﻿using ElectronicsShop.Domain.Users;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Auth
{
    public interface IAuthAppService
    {
        public Task<int> CreateUser(User user, string password);
        public Task<User> ValidateUser(string username, string password);
        public Task<string> CreateJwtToken(User user);
        public Task<User> GetLoggedInUser();
    }
}
