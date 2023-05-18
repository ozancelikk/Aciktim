using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.MessageBroker.Abstract
{
    public interface IMailSender
    {
        IResult Mail(string mail);
    }
}
