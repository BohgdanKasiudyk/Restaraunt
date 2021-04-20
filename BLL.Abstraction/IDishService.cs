using System.Collections.Generic;
using DTO;

namespace BLL.Abstraction
{
    public interface IDishService
    {
        IEnumerable<DishDTO> GetAllDishes();
        DishDTO GetById(int id);
    }
}