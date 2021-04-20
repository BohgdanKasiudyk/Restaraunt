using DAL.Abstraction.Repositories;
using DAL.Abstraction.UnitOfWork;
using DAL.Implementation.EnFr;
using DAL.Implementation.Repositories;

using DAL.Implementation.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Implementation
{
    public static class DALDepend
    {
        public static IServiceCollection RegisterServiceCollectionDAL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<RestaurantDbContext, RestaurantDbContext>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            serviceCollection.AddScoped<ICookRepository, CookRepository>();
            serviceCollection.AddScoped<IDishRepository, DishRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
           return serviceCollection;
        }
    }
}