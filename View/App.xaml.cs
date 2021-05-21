using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLL.Abstraction;
using BLL.Implementation;
using DAL.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterServiceCollectionBLL();
            serviceCollection.RegisterServiceCollectionDAL();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            ViewModel.ViewModel viewModel = new
                ViewModel.ViewModel(
                    _serviceProvider.GetService<IOrderService>(),
                    _serviceProvider.GetService<IMenuService>());

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = viewModel;
            MainWindow.Show();
        }

    }
}