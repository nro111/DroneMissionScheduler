using MongoDB.Driver;

namespace DroneMissionScheduler.Core.Interfaces
{
    public interface IDBContext
    {
        public IMongoCollection<T> GetCollection<T>(string name);
    }
}
