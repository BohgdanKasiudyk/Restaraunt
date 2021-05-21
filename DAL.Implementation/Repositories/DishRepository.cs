using DAL.Abstraction.Repositories;
using DAL.Implementation.EnFr;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation.Repositories
{
    public class DishRepository : GenericRepository<Dish, int>, IDishRepository
    {
        public DishRepository(RestaurantDbContext _dbContext) : base(_dbContext)
        {
            
        }
        
    }
}