using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.Enums
{
    public enum Role
    {
        Admin = 1,
        Customer = 0
    }

    public static class RoleName
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static string Name(this Role role)
        {
            return role.ToString();
        }
        public static Role GetEnum(string name)
        {
            switch(name)
            {
                case Admin:
                    return Role.Admin;
                case Customer:
                default:
                    return Role.Customer;
            }
        }
    }
}
