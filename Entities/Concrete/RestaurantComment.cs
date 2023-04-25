using Core.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RestaurantComment : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get ; set ; }
        public string RestaurantId { get ; set ; }
        public string CustomerId { get ; set ; }
        public string CommentTitle { get ; set ; }
        public string CommentContent { get ; set ; }
        public string CommentDate { get ; set ; }
        public double RestaurantRate { get ; set ; }
    }
}
