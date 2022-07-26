﻿using ElectronicsShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.Users
{
    public class User : Entity<int>
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string FullAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}
