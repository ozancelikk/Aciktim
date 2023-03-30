using Core.Entities.Concrete;
using Core.Entities.Concrete.DBEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcern.EMail
{
    public interface IMailManager
    {
        void SendMail(MailConfig eMailConfig, EMailContent eMailContent);
    }
}
