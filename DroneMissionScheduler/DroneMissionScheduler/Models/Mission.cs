using DroneMissionScheduler.Core.Interfaces;
using DroneMissionScheduler.Models.WeatherAPI;
using System.Collections.Generic;

namespace DroneMissionScheduler.Models
{
    public class Mission : IEntity<string>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public List<Pilot> Pilots { get; set; }
        public List<Drone> Drones { get; set; }
        public List<Weather> HourlyWeather { get; set; }
    }
}
