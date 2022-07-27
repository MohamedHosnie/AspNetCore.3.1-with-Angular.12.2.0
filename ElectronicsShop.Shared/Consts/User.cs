using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Shared.Consts
{
    public static class User
    {
        public const int Username_MinimumLength = 5;
        public const int Username_MaximumLength = 15;

        public const int FullName_MinimumLength = 5;
        public const int FullName_MaximumLength = 30;
        
        public const int FullAddress_MinimumLength = 5;
        public const int FullAddress_MaximumLength = 50;

        public const int Email_MinimumLength = 5;
        public const int Email_MaximumLength = 254;

        public const int PhoneNumber_MinimumLength = 5;
        public const int PhoneNumber_MaximumLength = 15;

        public const int Password_MinimumLength = 8;
        public const int Password_MaximumLength = 20;

        public const string PhoneNumber_Regex = @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$";

        public const string Email_Regex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    }
}
