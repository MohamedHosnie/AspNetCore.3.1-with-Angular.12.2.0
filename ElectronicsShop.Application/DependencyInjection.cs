using ElectronicsShop.Application.Auth;
using ElectronicsShop.Application.Orders;
using ElectronicsShop.Application.Products;
using ElectronicsShop.Application.Users;
using ElectronicsShop.Core.Orders;
using ElectronicsShop.Core.Products;
using ElectronicsShop.Domain.Repositories;
using ElectronicsShop.Core.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ElectronicsShop.EntityFrameworkCore.Repositories;

namespace ElectronicsShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            return services;
        }

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
