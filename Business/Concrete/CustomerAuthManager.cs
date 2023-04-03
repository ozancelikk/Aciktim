using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //public class CustomerAuthManager : ICustomerAuthService
    //{
    //    private readonly ICustomerService _customerservice;
    //    private readonly ITokenHelper _tokenHelper;
    //    private readonly IUserOperationClaimService _userOperationClaimService;
    //    private readonly IOperationClaimService _operationClaimService;
    //    private readonly ILoginActivitiesService _loginActivitiesService;
    //    private readonly IPasswordRecoveryService _passwordRecoveryService;

    //    public IDataResult<Customer> Register(CustomerForRegisterDto customerForRegisterDto)
    //    {

    //        HashingHelper.CreatePasswordHash(customerForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
    //        var customer = new Customer
    //        {
    //            MailAddress = customerForRegisterDto.Email,
    //            FirstName = customerForRegisterDto.FirstName,
    //            LastName = customerForRegisterDto.LastName,
    //            PasswordHash = passwordHash,
    //            PasswordSalt = passwordSalt,
    //        };

    //        _customerservice.Add(customer);
    //        var userForDefaultOperationClaim = _customerservice.GetByMail(customer.MailAddress);
    //        if (userForDefaultOperationClaim.Success)
    //        {
    //            var defaultClaim = _operationClaimService.GetByClaimName("admin");

    //            var userOperationClaim = new UserOperationClaimDto
    //            {
    //                OperationClaimId = defaultClaim.Data.Id,
    //                UserId = userForDefaultOperationClaim.Data.Id
    //            };

    //            _userOperationClaimService.Add(userOperationClaim);
    //        }


    //        return new SuccessDataResult<Customer>(customer, Messages.CustomerRegistered);
    //    }


    //    //[ValidationAspect(typeof(AuthValidatorForLogin))]
    //    public IDataResult<Customer> Login(CustomerForLoginDto customerForLoginDto)
    //    {
    //        var customerToCheck = _customerservice.GetByMail(customerForLoginDto.Email);
    //        if (customerToCheck.Data == null)
    //        {
    //            return new ErrorDataResult<Customer>("asdfasşlkfma");
    //        }

    //        if (!HashingHelper.VerifyPasswordHash(customerForLoginDto.Password, customerToCheck.Data.PasswordHash, customerToCheck.Data.PasswordSalt))
    //        {
    //            //_loginActivities.Add(new LoginActivities { DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), User = userForLoginDto.Email, Type = "Login Failed" });
    //            return new ErrorDataResult<Customer>("as,faösifşöa");
    //        }
    //        //_loginActivities.Add(new LoginActivities { DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), User = userForLoginDto.Email, Type = "Login Success" });
    //        return new SuccessDataResult<Customer>(customerToCheck.Data, Messages.SuccessfulLogin);
    //    }

    //    //[BusinessForgotPasswordAspect]
    //    public IResult ForgotPassword(string eMail)
    //    {
    //        var result = _customerservice.GetByMail(eMail);
    //        if (result.Data != null)
    //        {
    //            return new SuccessResult(eMail + " mail adresine aktivasyon kodu gönderdik. Lüften mail adresinizi kontrol ederek gelen kodu aşağıdaki alana giriniz.");
    //        }
    //        return new ErrorResult("Eksik yada hatalı bir giriş yaptınız.");
    //    }

    //    public IResult ChangeForgottenPassword(ForgottenPassword forgottenPassword)
    //    {
    //        var result = _passwordRecoveryService.GetByEMail(forgottenPassword.Email);

    //        if (result.Data != null)
    //        {
    //            if (result.Data.PrivateKey != forgottenPassword.PrivateKey)
    //            {
    //                return new ErrorResult("Yanlış aktivasyon kodu girdiniz.");
    //            }
    //            var user = _customerservice.GetByMail(forgottenPassword.Email);
    //            HashingHelper.CreatePasswordHash(forgottenPassword.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
    //            user.Data.PasswordSalt = passwordSalt;
    //            user.Data.PasswordHash = passwordHash;
    //            _customerservice.ChangeForgottenPassword(user.Data);
    //            _passwordRecoveryService.Delete(user.Data.MailAddress);
    //            return new SuccessResult(Messages.Successful);
    //        }
    //        return new ErrorResult(Messages.Unsuccessful);
    //    }

    //    public IResult UserExists(string email)
    //    {
    //        if (_customerservice.GetByMail(email).Data != null)
    //        {
    //            return new ErrorResult(Messages.UserAlreadyExists);
    //        }
    //        return new SuccessResult(Messages.Successful);
    //    }

    //    public IDataResult<AccessToken> CreateAccessToken(Customer customer)
    //    {
    //        var claims = _customerservice.GetClaims(customer);
    //        var accessToken = _tokenHelper.CreateToken(customer, claims.Data);
    //        return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
    //    }
    //}
}
