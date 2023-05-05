using Core.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete.DBEntities
{
    public class Restaurant : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RestaurantName { get; set; }
        public string MailAddress { get; set; }
        public string RestaurantAddress { get; set; }
        public string TaxNumber { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string PhoneNumber { get; set; }
        public double RestaurantRate { get; set; }
        public double MinCartPrice { get; set; }
        public string CategoryId { get; set; }
        public string RegisterDate { get; set; }
        public bool Status { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
