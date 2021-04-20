using Microsoft.Extensions.DependencyInjection;
using RestaurantConsole.Abstraction;
using RestaurantConsole.Impementation;

namespace RestaurantConsole
{
    public static class CONDepend
    {
        public static IServiceCollection RegisterServiceCollectionCON(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IDataWriter), typeof(DataWriter));
            services.AddSingleton(typeof(IDataReader), typeof(DataReader));
            services.AddSingleton(typeof(IUI), typeof(UI));
            return services;
        }
    }
}