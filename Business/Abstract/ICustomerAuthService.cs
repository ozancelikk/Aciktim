using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerAuthService
    {
        IDataResult<Customer> Register(CustomerForRegisterDto customerForRegisterDto);
        IDataResult<Customer> Login(CustomerForLoginDto customerForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Customer customer);
        IResult ForgotPassword(string eMail);
        IResult ChangeForgottenPassword(ForgettenPasswordForCustomer forgettenPasswordForCustomer);
        IResult ChangePassword(CustomerChangePasswordDto customerChangePasswordDto);
	}
}
