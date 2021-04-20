

using System.Collections.Generic;
using Entities;

namespace DAL.Abstraction.Repositories
{
   public interface IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
       {
           IEnumerable<TEntity> GetAll();
           TEntity Read(Tkey id);
           void Create(TEntity item);
           void Delete(TEntity item);
           void Update(TEntity item);
       }
}