using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace BackendInnovation.Models
{
    public class Segment
    {
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public double Value { get; set; }

        public string IdeaId { get; set; }

        public Segment()
        {
            Id = ObjectId.GenerateNewId();
        }
    }
}
