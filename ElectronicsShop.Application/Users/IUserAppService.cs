using ElectronicsShop.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Application.Users
{
    public interface IUserAppService
    {
        public User GetUserById(int value);
    }
}
