using DAL.Abstraction.Repositories;

namespace DAL.Abstraction.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICookRepository Cooks {get; }
        IDishRepository Dishes { get;  }
        IOrderRepository Orders { get; }
        
        IMenuRepository Menus { get; }
        
        IDishMenuRepository DishMenus { get;  }

        void Save();
    }
}