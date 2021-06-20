﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mongo.Database.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.1, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }
        [Required]
        public string Author { get; set; }
        public string Language { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public int Pages { get; set; }
        public Publisher Publisher { get; set; }
    }
}
