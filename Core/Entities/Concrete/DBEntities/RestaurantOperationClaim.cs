using Core.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete.DBEntities
{
    public class RestaurantOperationClaim : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public string OperationClaimId { get; set; }
    }
}
