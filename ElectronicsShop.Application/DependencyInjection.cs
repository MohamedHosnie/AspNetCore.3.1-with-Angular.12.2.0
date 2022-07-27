using ElectronicsShop.Application.Auth;
using ElectronicsShop.Application.Users;
using ElectronicsShop.Core;
using ElectronicsShop.Core.Users;
using ElectronicsShop.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

            services.AddScoped<IRepository<User, int>, Repository<User, int>>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {


            return services;
        }
    }
}
