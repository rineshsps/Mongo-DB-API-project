using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.DTOs
{
    public class BookDisplayDTO
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public int Pages { get; set; }
        public PublisherDTO Publisher { get; set; }
    }
}
