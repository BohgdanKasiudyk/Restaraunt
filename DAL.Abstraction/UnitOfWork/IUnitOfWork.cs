using DAL.Abstraction.Repositories;

namespace DAL.Abstraction.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICookRepository Cooks {get; }
        IDishRepository Dishes { get;  }
        IOrderRepository Orders { get; }

        void Save();
    }
}