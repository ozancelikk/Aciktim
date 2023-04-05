using Core.Entities.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CustomerAddresses : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string NeighbourHood { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }
        public string DoorNumber { get; set; }
        public string Address { get; set; }
    }
}
