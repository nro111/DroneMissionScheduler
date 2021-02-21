using System.Collections.Generic;

namespace DroneMissionScheduler.Core.Interfaces
{
    public interface IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        IEntity<TKey> Get(TKey key);
        IEnumerable<TEntity> GetRange(IEnumerable<TKey> keys);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TKey key);
    }
}