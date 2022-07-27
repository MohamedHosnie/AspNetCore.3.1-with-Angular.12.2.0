using ElectronicsShop.Shared.Enums;
using ElectronicsShop.Core.Products;
using ElectronicsShop.Core.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.EntityFrameworkCore
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "TVs"
                },
                new Category
                {
                    Id = 2,
                    Name = "Laptops"
                },
                new Category
                {
                    Id = 3,
                    Name = "Sound Systems"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    BirthDate = DateTime.Now,
                    Email = "sample@email.com",
                    FullAddress = "Cairo, Egypt",
                    FullName = "Electronics Shop Admin",
                    PhoneNumber = "011111",
                    Role = Role.Admin,
                    PasswordHash = "$2a$11$UBds5HSkR4cEPlGDo8lUyOCNOBmen37At0FJA8/kIgNdjUdMBxHUu"
                }
            );
        }
    }
}
