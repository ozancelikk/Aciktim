using Core.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class FavoriteRestaurantDto:IDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string OpeningTime { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string ClosingTime { get; set; }
        public double RestaurantRate { get; set; }
        public double MinCartPrice { get; set; }
        public string CategoryId { get; set; }
        public string? imagePath { get; set; }
  

    }
}
