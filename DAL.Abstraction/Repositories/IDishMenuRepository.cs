using System.Collections.Generic;
using Entities;

namespace DAL.Abstraction.Repositories
{
    public interface IDishMenuRepository: IGenericRepository<DishMenu, int>
    {

        IEnumerable<DishMenu> selectDishMenusByMenuId(int menuId);

    }
    
     
}