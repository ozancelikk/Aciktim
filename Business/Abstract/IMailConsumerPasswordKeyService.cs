using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMailConsumerPasswordKeyService
    {
        IResult Add(MailConsumerPasswordKey mailConsumerPasswordKey);
        IResult Delete(string id);
        IDataResult<List<MailConsumerPasswordKey>> GetAll();
        IDataResult<List<MailConsumerPasswordKey>> Get(string id);
        IDataResult<MailConsumerPasswordKey> GetByMail(string mail);
        IResult asd(string key, string mail);
    }
}
