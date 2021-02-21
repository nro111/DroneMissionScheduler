using DroneMissionScheduler.Core.Interfaces;

namespace DroneMissionScheduler.Models
{
    public class Pilot : IEntity<string>
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CertificationType { get; set; }
    }
}
