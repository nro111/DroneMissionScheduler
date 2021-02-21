using DroneMissionScheduler.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneMissionScheduler.Core
{
    public abstract class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        internal ApplicationContext context;

        internal DbSet<TEntity> dbSet;
        protected Repository(/*parameter you may need to implement the generic methods, like a ConnectionFactory,  table name, entity type for casts, etc */) 
        { 
        }
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        public void Delete(TKey key)
        {
            throw new NotImplementedException();
        }
        public IEntity<TKey> Get(TKey key)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TEntity> GetRange(IEnumerable<TKey> keys)
        {
            throw new NotImplementedException();
        }
        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}