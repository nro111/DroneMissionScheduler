using DroneMissionScheduler.Core.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneMissionScheduler.Core
{
    public class DBContext : IDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public DBContext()
        {
            _mongoClient = new MongoClient("mongodb+srv://MissionScheduleAdmin:E5DLTMCqOybDqFyw@missionschedules.00l2e.mongodb.net?connect=replicaSet");
            _db = _mongoClient.GetDatabase("MissionDB");            
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
