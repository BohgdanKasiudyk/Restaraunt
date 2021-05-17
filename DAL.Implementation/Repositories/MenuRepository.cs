using DAL.Abstraction.Repositories;
using DAL.Implementation.EnFr;
using Entities;

namespace DAL.Implementation.Repositories
{
    public class MenuRepository: GenericRepository<Menu, int>, IMenuRepository
    {
        public MenuRepository(RestaurantDbContext _dbContext) : base(_dbContext)
        {
            
        }
    }
}