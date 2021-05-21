using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BLL.Abstraction;
using BLL.Implementation.Mappers;
using DAL.Abstraction.UnitOfWork;
using DTO;
using Entities;

namespace BLL.Implementation.Services
{
    public class MenuService : IMenuService

    {

        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<MenuDTO> GetALLMenus()
        {
            return _unitOfWork.Menus.GetAll().Select(m => m.toDTO());
        }

        public IEnumerable<DishDTO> GetAllDishesFromMenu(int menuId)
        {
            IEnumerable<DishMenu> dishMenus = _unitOfWork.DishMenus.selectDishMenusByMenuId(menuId);
            List<DishDTO> dishDtos = new List<DishDTO>();
            foreach (var dishmenu in dishMenus)
            {
                dishDtos.Add(_unitOfWork.Dishes.Read(dishmenu.DishId).ToDto());
            }

            return dishDtos;

        }
    }
}