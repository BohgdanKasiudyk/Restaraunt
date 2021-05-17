using BLL.Abstraction;
using BLL.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Implementation
{
    public static class BLLDepend
    {
        public static IServiceCollection RegisterServiceCollectionBLL(this IServiceCollection services)
        {
            services.AddSingleton<ICookService, CookService>();
            services.AddSingleton<IDishService, DishService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IMenuService, MenuService>(); 
            

            return services;
        }
    }
}