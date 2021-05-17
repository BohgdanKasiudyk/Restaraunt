using System.Collections;
using System.Collections.Generic;
using DTO;
using Entities;

namespace BLL.Abstraction
{
    public interface IMenuService
    {
        IEnumerable<Menu> GetALLMenus();
        IEnumerable<DishDTO> GetAllDishesFromMenu(int menuId);
    }
}