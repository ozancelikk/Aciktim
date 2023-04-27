using Core.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Support : IEntity
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set ; }
        public string CustomerId { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
