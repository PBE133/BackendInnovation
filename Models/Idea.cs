
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using BackendInnovation.Models;
using System.Text.Json.Serialization;

namespace BackendInnovation.Models
{
    public class Idea
    {
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdatedAt { get; set; }
        public string Portfolio_id { get; set; } = String.Empty;
        public string IdeatorId { get; set; }

        public Idea()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}
