using ElectronicsShop.Shared.Enums;
using ElectronicsShop.Domain.Products;
using ElectronicsShop.Domain.Users;
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

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Test Product 1",
                    Description = "This is a test dummy data description",
                    Price = 600,
                    PriceOfTwo = 1100,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 2,
                    Name = "Test Product 2",
                    Description = "This is a test dummy data description",
                    Price = 1500,
                    PriceOfTwo = null,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 3,
                    Name = "Test Product 3",
                    Description = "This is a test dummy data description",
                    Price = 2200,
                    PriceOfTwo = 4000,
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 4,
                    Name = "Test Product 4",
                    Description = "This is a test dummy data description",
                    Price = 2400,
                    PriceOfTwo = 4500,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 5,
                    Name = "Test Product 5",
                    Description = "This is a test dummy data description",
                    Price = 3800,
                    PriceOfTwo = 6800,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 6,
                    Name = "Test Product 6",
                    Description = "This is a test dummy data description",
                    Price = 1100,
                    PriceOfTwo = 2000,
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 7,
                    Name = "Test Product 7",
                    Description = "This is a test dummy data description",
                    Price = 1700,
                    PriceOfTwo = 3000,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 8,
                    Name = "Test Product 8",
                    Description = "This is a test dummy data description",
                    Price = 7200,
                    PriceOfTwo = null,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 9,
                    Name = "Test Product 9",
                    Description = "This is a test dummy data description",
                    Price = 500,
                    PriceOfTwo = 800,
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 10,
                    Name = "Test Product 10",
                    Description = "This is a test dummy data description",
                    Price = 660,
                    PriceOfTwo = 1000,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 11,
                    Name = "Test Product 11",
                    Description = "This is a test dummy data description",
                    Price = 770,
                    PriceOfTwo = null,
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 12,
                    Name = "Test Product 12",
                    Description = "This is a test dummy data description",
                    Price = 850,
                    PriceOfTwo = 1600,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 13,
                    Name = "Test Product 13",
                    Description = "This is a test dummy data description",
                    Price = 750,
                    PriceOfTwo = null,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 14,
                    Name = "Test Product 14",
                    Description = "This is a test dummy data description",
                    Price = 940,
                    PriceOfTwo = 1750,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 15,
                    Name = "Test Product 15",
                    Description = "This is a test dummy data description",
                    Price = 456,
                    PriceOfTwo = 700,
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 16,
                    Name = "Test Product 16",
                    Description = "This is a test dummy data description",
                    Price = 778,
                    PriceOfTwo = null,
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 17,
                    Name = "Test Product 17",
                    Description = "This is a test dummy data description",
                    Price = 666,
                    PriceOfTwo = 1111,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 18,
                    Name = "Test Product 18",
                    Description = "This is a test dummy data description",
                    Price = 999,
                    PriceOfTwo = 1700,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 19,
                    Name = "Test Product 19",
                    Description = "This is a test dummy data description",
                    Price = 888,
                    PriceOfTwo = 1500,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 20,
                    Name = "Test Product 20",
                    Description = "This is a test dummy data description",
                    Price = 254,
                    PriceOfTwo = null,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 21,
                    Name = "Test Product 21",
                    Description = "This is a test dummy data description",
                    Price = 256,
                    PriceOfTwo = 512,
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 22,
                    Name = "Test Product 22",
                    Description = "This is a test dummy data description",
                    Price = 512,
                    PriceOfTwo = null,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 23,
                    Name = "Test Product 23",
                    Description = "This is a test dummy data description",
                    Price = 128,
                    PriceOfTwo = 256,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 24,
                    Name = "Test Product 24",
                    Description = "This is a test dummy data description",
                    Price = 1024,
                    PriceOfTwo = 2048,
                    CategoryId = 3,
                }
            );
        }
    }
}
