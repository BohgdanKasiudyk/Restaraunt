using DAL.Abstraction.Repositories;
using DAL.Implementation.EnFr;
using Entities;

namespace DAL.Implementation.Repositories
{
    public class DishMenuRepository: GenericRepository<DishMenu, int>, IDishMenuRepository
    
    {

        public DishMenuRepository(RestaurantDbContext _dbContext) : base(_dbContext)
        {
            
        }
        
    }
}