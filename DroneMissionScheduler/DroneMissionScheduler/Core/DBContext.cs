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
            _mongoClient = new MongoClient("mongodb+srv://MissionScheduleAdmin:This16@D6)!@missionschedules.00l2e.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            _db = _mongoClient.GetDatabase("test");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
