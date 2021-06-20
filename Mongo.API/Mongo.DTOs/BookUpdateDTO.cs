using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mongo.DTOs
{
    public class BookUpdateDTO
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Range(1, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }
        [Required]
        [MinLength(2)]
        public string Author { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        [Range(4, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Pages { get; set; }
        public PublisherDTO Publisher { get; set; }
    }
}
