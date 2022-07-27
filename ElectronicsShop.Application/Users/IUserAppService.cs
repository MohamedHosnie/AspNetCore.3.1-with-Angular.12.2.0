using ElectronicsShop.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsShop.Application.Users
{
    public interface IUserAppService
    {
        public bool UsernameIsUnique(string username);
    }
}
