using DroneMissionScheduler.Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DroneMissionScheduler.Models
{
    public class Pilot
    {
        [BsonId]
        public ObjectId _id { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }
        [BsonElement("LastName")]
        public string LastName { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("CertificationType")]
        public string CertificationType { get; set; }
    }
}
