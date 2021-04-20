using System.Collections.Generic;
using DAL.Abstraction.Repositories;
using DAL.Implementation.EnFr;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DAL.Implementation.Repositories
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        private readonly RestaurantDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(RestaurantDbContext _dbContext)
        {
            this._dbContext = _dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual TEntity Read(Tkey id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual void Update(TEntity entity)
        {
            TEntity current = Read(entity.Id);
            _dbContext.Entry(current).CurrentValues.SetValues(entity);
            
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(Read(entity.Id));
        }
    }
    
    
   
}