using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPasswordRecoveryService
    {
        IResult Add(PasswordRecovery passwordRecovery);
        IDataResult<PasswordRecovery> Get();
        IDataResult<PasswordRecovery> GetByEMail(string eMail);
        IDataResult<List<PasswordRecovery>> GetAll();
        IResult Update(PasswordRecovery passwordRecovery);
        IResult Delete(string eMail);
    }
}
