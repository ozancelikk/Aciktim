using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class CustomerDetailsDto:IDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }
        public string BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string RegisterDate { get; set; }
    }
}
