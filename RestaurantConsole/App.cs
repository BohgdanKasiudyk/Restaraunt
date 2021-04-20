using BLL.Implementation;
using DAL.Implementation;
using Microsoft.Extensions.DependencyInjection;
using RestaurantConsole.Abstraction;

namespace RestaurantConsole
{
    public class App
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            Configure(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterServiceCollectionBLL();
            serviceCollection.RegisterServiceCollectionDAL();
            serviceCollection.RegisterServiceCollectionCON();
        }

        public void Run()
        {
            IUI console = _serviceProvider.GetRequiredService<IUI>();
            console.Show();
        }
    }
}