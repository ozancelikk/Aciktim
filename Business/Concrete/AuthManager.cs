using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    internal class AuthManager : IAuthService
    {
        
        public IResult ChangeForgottenPassword(ForgottenPassword forgottenPassword)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public IResult ForgotPassword(string eMail)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
