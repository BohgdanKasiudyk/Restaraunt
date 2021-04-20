using DAL.Abstraction.Repositories;
using DAL.Implementation.EnFr;
using Entities;

namespace DAL.Implementation.Repositories
{
    public class CookRepository: GenericRepository<Cook, int>, ICookRepository
    {
        public CookRepository(RestaurantDbContext _dbContext) : base(_dbContext)
        {
            
        }
    }
}