using Core.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities.Concrete.DBEntities
{
    public class Customer : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }
        public string BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string RegisterDate { get; set; }
        public string MailAddress { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
