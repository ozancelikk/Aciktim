using Core.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderComment:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string RestaurantName { get; set; }
        public string CustomerMail { get; set; }
        public string? Content { get; set; }
        public int? OrderStar { get; set; }
        public string OrderCommentDate { get; set; }
    }
}
