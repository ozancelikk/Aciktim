using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MailConsumerPasswordKeyDto:IDto
    {
        public string Mail { get; set; }
        public string PrivateKey { get; set; }
    }
}
