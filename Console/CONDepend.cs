using Microsoft.Extensions.DependencyInjection;

namespace Console
{
    public static class CONDepend
    {
        public static IServiceCollection RegisterServiceCollectionCON(this IServiceCollection services)
        {
            services.AddSingleton<ICMD, CMD>();
            return services;
        }
        
    }
}