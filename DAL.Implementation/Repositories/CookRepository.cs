using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Abstraction.Repositories;
using DAL.Implementation.EnFr;
using Entities;

namespace DAL.Implementation.Repositories
{
    public class CookRepository: GenericRepository<Cook, int>, ICookRepository
    {
        public CookRepository(RestaurantDbContext _dbContext) : base(_dbContext)
        {
            
        }

        public IEnumerable<Cook> getFreeCooks(DateTime startOrder, int specializationId)
        {
            return _dbSet.Where(c => startOrder > c.WhenIsFree).Where(c => c.SpecializationId == specializationId).ToList();
        }
    }
}