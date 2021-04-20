using DAL.Abstraction.Repositories;
using DAL.Implementation.EnFr;
using Entities;

namespace DAL.Implementation.Repositories
{
    public class OrderRepository: GenericRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(RestaurantDbContext _dbContext) : base(_dbContext)
        {
            
        }
    }
}