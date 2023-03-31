using Core.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Restaurant:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string TaxNumber { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string CategoryId { get; set; }
        public string? RestaurantImage { get; set; }
    }
}
