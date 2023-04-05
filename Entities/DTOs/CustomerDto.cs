﻿using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class CustomerDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }
        public string BirthDay { get; set; }
        public string Phonenumber { get; set; }
        public string MailAddress { get; set; }
    }
}
