using System;
using System.Collections.Generic;
using Entities;

namespace DAL.Abstraction.Repositories
{
    public interface ICookRepository : IGenericRepository<Cook, int>
    {
        IEnumerable<Cook> getFreeCooks(DateTime startOrder, int specializationId);
    }
}