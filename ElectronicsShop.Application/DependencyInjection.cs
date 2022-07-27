using ElectronicsShop.Application.Auth;
using ElectronicsShop.Application.Users;
using ElectronicsShop.Core.Repositories;
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
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
