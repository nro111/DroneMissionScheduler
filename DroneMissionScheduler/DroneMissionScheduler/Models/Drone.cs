using DroneMissionScheduler.Core.Interfaces;

namespace DroneMissionScheduler.Models
{
    public class Drone : IEntity<string>
    {
        public int ID { get; set; }
        public string Nickname { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int SerialNumber { get; set; }
        public int YearManufactured { get; set; }
    }
}