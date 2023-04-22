using Core.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Dtos;
using Entities.DTOs;

namespace Entities.Concrete
{
    [BsonDiscriminator("Order")]
    public class Order:IEntity
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string OrderDescription { get; set; }
        public string Address { get; set; }
        public string OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string EstimatedTime { get; set; }
        public List<OrderMenuDetail>? Menus { get; set; }
    }
}
