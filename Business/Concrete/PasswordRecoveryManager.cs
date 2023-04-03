using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PasswordRecoveryManager : IPasswordRecoveryService
    {
        private readonly IPasswordRecoveryDal _passwordRecoveryDal;
        public PasswordRecoveryManager(IPasswordRecoveryDal passwordRecoveryDal)
        {
            _passwordRecoveryDal = passwordRecoveryDal;

        }
        public IResult Add(PasswordRecovery passwordRecovery)
        {
            _passwordRecoveryDal.Add(passwordRecovery);
            return new SuccessResult("Ekleme işlemi başarılı");
        }
        public IResult Delete(string eMail)
        {
            var result = GetByEMail(eMail);
            if (result.Success)
            {
                _passwordRecoveryDal.Delete(result.Data);
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }
        public IResult Update(PasswordRecovery passwordRecovery)
        {
            var result = _passwordRecoveryDal.Update(passwordRecovery);
            if (result.ModifiedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<PasswordRecovery> Get()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<PasswordRecovery>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<PasswordRecovery> GetByEMail(string eMail)
        {
            return new SuccessDataResult<PasswordRecovery>(_passwordRecoveryDal.Get(p => p.MailAddress == eMail), Messages.Successful);

        }
    }
}
