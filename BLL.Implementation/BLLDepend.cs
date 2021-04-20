using BLL.Abstraction;
using BLL.Implementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Implementation
{
    public static class BLLDepend
    {
        public static IServiceCollection RegisterServiceCollectionBLL(this IServiceCollection services)
        {
            services.AddTransient<ICookService, CookService>();
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IOrderService, OrderService>();

            return services;
        }
    }
}