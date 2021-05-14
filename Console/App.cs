using System.Diagnostics.CodeAnalysis;
using BLL.Abstraction;
using BLL.Implementation;
using DAL.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Console
{
    public class App
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            Configure(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void Configure(IServiceCollection serviceCollection)
        {
            
            serviceCollection.RegisterServiceCollectionDAL();
            serviceCollection.RegisterServiceCollectionBLL();
        }

        public void Run()
        {
            ICMD console = new CMD(_serviceProvider.GetRequiredService<IDishService>(),
                _serviceProvider.GetRequiredService<IOrderService>());
            console.Show();
        }
    }
}