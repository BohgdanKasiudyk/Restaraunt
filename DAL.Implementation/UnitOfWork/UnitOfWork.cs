using DAL.Abstraction.Repositories;
using DAL.Abstraction.UnitOfWork;
using DAL.Implementation.EnFr;

namespace DAL.Implementation.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDbContext _dbContext;
        public ICookRepository Cooks { get;  }
        public IDishRepository Dishes { get; }
        public IOrderRepository Orders { get;  }

        public UnitOfWork(RestaurantDbContext _dbContext, IDishRepository dishRepository,
            ICookRepository cookRepository, IOrderRepository orderRepository)
        {
            this._dbContext = _dbContext;
            Cooks = cookRepository;
            Dishes = dishRepository;
            Orders = orderRepository;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}