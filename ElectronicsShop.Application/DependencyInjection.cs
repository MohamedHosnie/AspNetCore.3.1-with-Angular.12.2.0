using ElectronicsShop.Application.Auth;
using ElectronicsShop.Application.Orders;
using ElectronicsShop.Application.Products;
using ElectronicsShop.Application.Users;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
