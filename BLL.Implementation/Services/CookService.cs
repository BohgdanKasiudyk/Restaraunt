using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Abstraction;
using DAL.Abstraction.UnitOfWork;
using Entities;

namespace BLL.Implementation.Services
{
    public class CookService: ICookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CookService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Cook GetReadyCook(DateTime startOrder, int specializationId)
        {
            IEnumerable<Cook> cooks = _unitOfWork.Cooks.GetAll();
            IEnumerable<Cook> freeCooks =
                cooks.Where(c => startOrder > c.WhenIsFree).Where(c => c.SpecializationId == specializationId).ToList();

            if (freeCooks.Count() == 0)
            {
                return cooks.OrderBy(c => c.WhenIsFree).Where(c => c.SpecializationId == specializationId).First();
            }

            return freeCooks.OrderBy(c => c.Efficiency).First();
        }
    }
}