using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.Users
{
    public class User : Entity<int>
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
