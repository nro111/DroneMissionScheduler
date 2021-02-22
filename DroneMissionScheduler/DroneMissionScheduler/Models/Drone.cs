using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DroneMissionScheduler.Models
{
    public class Drone
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("Nickname")]
        public string Nickname { get; set; }
        [BsonElement("Make")]
        public string Make { get; set; }
        [BsonElement("Model")]
        public string Model { get; set; }
        [BsonElement("SerialNumber")]
        public int SerialNumber { get; set; }
        [BsonElement("YearManufactured")]
        public int YearManufactured { get; set; }
    }
}