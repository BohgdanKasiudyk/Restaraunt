using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<DishMenu> selectDishMenusByMenuId(int menuId)
        {
            return _dbSet.Where(i => i.MenuId == menuId).ToList();
        }
    }
}