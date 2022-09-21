using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using BackendInnovation.Models;
using System.Text.Json.Serialization;

namespace BackendInnovation
{
    public class Ideator
    {
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("ideatorName")]
        public string? Name { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [BsonElement("company")]
        public string? Company { get; set; }

        public Ideator()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}
