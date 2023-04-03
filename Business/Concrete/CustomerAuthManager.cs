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
    public class CustomerAuthManager : ICustomerAuthService
    {
        public IResult ChangeForgottenPassword(ForgettenPasswordForCustomer forgettenPasswordForCustomer)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> CreateAccessToken(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult ForgotPassword(string eMail)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(CustomerForLoginDto customerForLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Customer> Register(CustomerForRegisterDto customerForRegisterDto)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
