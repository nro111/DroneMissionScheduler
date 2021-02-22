using DroneMissionScheduler.Core.Interfaces;
using DroneMissionScheduler.Models.WeatherAPI;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DroneMissionScheduler.Models
{
    public class Mission
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("StartDate")]
        public string StartDate { get; set; }
        [BsonElement("EndDate")]
        public string EndDate { get; set; }
        [BsonElement("Location")]
        public string Location { get; set; }
        [BsonElement("Details")]
        public string Details { get; set; }
        [BsonElement("Pilots")]
        public List<Pilot> Pilots { get; set; }
        [BsonElement("Drones")]
        public List<Drone> Drones { get; set; }
        [BsonElement("HourlyWeather")]
        public List<WeatherDataRoot> HourlyWeather { get; set; }
    }
}
