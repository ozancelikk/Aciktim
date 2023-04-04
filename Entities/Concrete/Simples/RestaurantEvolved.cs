using Core.Entities.Concrete.DBEntities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Simples
{
    public class RestaurantEvolved
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public string RestaurantName { get; set; }
        public List<OperationClaim> OperationClaims { get; set; }
    }
}
