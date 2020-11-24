using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuAPI.Models
{
    public class Dish
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string TimeAvailable { get; set; }
        public bool IsAvailable { get; set; }
        public string TimeToServe { get; set; }
    }
}