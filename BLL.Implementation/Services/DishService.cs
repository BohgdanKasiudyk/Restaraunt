using System.Collections.Generic;
using System.Linq;
using BLL.Abstraction;
using BLL.Implementation.Mappers;
using DAL.Abstraction.UnitOfWork;
using DTO;

namespace BLL.Implementation.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DishService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<DishDTO> GetAllDishes()
        {
            return _unitOfWork.Dishes.GetAll().Select(d => d.ToDto()).ToList();
        }

        public DishDTO GetById(int id)
        {
            return _unitOfWork.Dishes.Read(id).ToDto();
        }
    }
}