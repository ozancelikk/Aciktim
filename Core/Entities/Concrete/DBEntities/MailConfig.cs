using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete.DBEntities
{
    public class MailConfig:IEntity
    {
        public string Id { get; set; }
        public string SmtpServer { get; set; }
        public string From { get; set; }
        public List<string> To { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}
