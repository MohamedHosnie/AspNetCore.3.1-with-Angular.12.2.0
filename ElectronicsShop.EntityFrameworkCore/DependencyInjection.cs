using ElectronicsShop.Domain.Orders;
using ElectronicsShop.Domain.Products;
using ElectronicsShop.Domain.Repositories;
using ElectronicsShop.Domain.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ElectronicsShop.EntityFrameworkCore.Repositories;

namespace ElectronicsShop.EntityFrameworkCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Product, int>, Repository<Product, int>>();
            services.AddScoped<IRepository<Category, short>, Repository<Category, short>>();
            services.AddScoped<IRepository<Order, int>, Repository<Order, int>>();
            return services;
        }
    }
}
