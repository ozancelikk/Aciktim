using Business.Abstract;
using Business.Constants;
using Castle.Core.Resource;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RestaurantAuthManager : IRestaurantAuthService
    {

        private readonly IRestaurantService _restaurantService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRestaurantOperationClaimService _restaurantOperationClaimService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly ILoginActivitiesService _loginActivitiesService;
        private readonly IPasswordRecoveryService _passwordRecoveryService;

        public RestaurantAuthManager(IRestaurantService restaurantService, ITokenHelper tokenHelper, IRestaurantOperationClaimService restaurantOperationClaimService, IOperationClaimService operationClaimService, ILoginActivitiesService loginActivitiesService, IPasswordRecoveryService passwordRecoveryService)
        {
            _restaurantService = restaurantService;
            _tokenHelper = tokenHelper;
            _restaurantOperationClaimService = restaurantOperationClaimService;
            _operationClaimService = operationClaimService;
            _loginActivitiesService = loginActivitiesService;
            _passwordRecoveryService = passwordRecoveryService;
        }

        public IResult ChangeForgottenPassword(ForgettenPasswordForRestaurant forgettenPasswordForRestaurant)
        {
            var result = _passwordRecoveryService.GetByEMail(forgettenPasswordForRestaurant.Email);

            if (result.Data != null)
            {
                if (result.Data.PrivateKey != forgettenPasswordForRestaurant.PrivateKey)
                {
                    return new ErrorResult("Yanlış aktivasyon kodu girdiniz.");
                }
                var user = _restaurantService.GetByMail(forgettenPasswordForRestaurant.Email);
                HashingHelper.CreatePasswordHash(forgettenPasswordForRestaurant.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
                user.Data.PasswordSalt = passwordSalt;
                user.Data.PasswordHash = passwordHash;
                _restaurantService.ChangeForgottenPassword(user.Data);
                _passwordRecoveryService.Delete(user.Data.MailAddress);
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<RestaurantAccessToken> CreateAccessToken(Restaurant restaurant)
        {
            var claims = _restaurantService.GetClaims(restaurant);
            var accessToken = _tokenHelper.CreateTokenForRestaurant(restaurant, claims.Data);
            return new SuccessDataResult<RestaurantAccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult ForgotPassword(string eMail)
        {
            var result = _restaurantService.GetByMail(eMail);
            if (result.Data != null)
            {
                return new SuccessResult(eMail + " mail adresine aktivasyon kodu gönderdik. Lüften mail adresinizi kontrol ederek gelen kodu aşağıdaki alana giriniz.");
            }
            return new ErrorResult("Eksik yada hatalı bir giriş yaptınız.");
        }

        public IDataResult<Restaurant> Login(RestaurantForLoginDto restaurantForLoginDto)
        {
            var customerToCheck = _restaurantService.GetByMail(restaurantForLoginDto.Email);
            if (customerToCheck.Data == null)
            {
                return new ErrorDataResult<Restaurant>("asdfasşlkfma");
            }

            if (!HashingHelper.VerifyPasswordHash(restaurantForLoginDto.Password, customerToCheck.Data.PasswordHash, customerToCheck.Data.PasswordSalt))
            {
                //_loginActivities.Add(new LoginActivities { DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), User = userForLoginDto.Email, Type = "Login Failed" });
                return new ErrorDataResult<Restaurant>("as,faösifşöa");
            }
            //_loginActivities.Add(new LoginActivities { DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), User = userForLoginDto.Email, Type = "Login Success" });
            return new SuccessDataResult<Restaurant>(customerToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<Restaurant> Register(RestaurantForRegisterDto restaurantForRegisterDto)
        {
            HashingHelper.CreatePasswordHash(restaurantForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var restaurant = new Restaurant
            {
                MailAddress = restaurantForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status=false,
                OpeningTime= restaurantForRegisterDto.OpeningTime,
                CategoryId=restaurantForRegisterDto.CategoryId,
                ClosingTime = restaurantForRegisterDto.ClosingTime,
                MinCartPrice = restaurantForRegisterDto.MinCartPrice,
                PhoneNumber = restaurantForRegisterDto.PhoneNumber,
                RestaurantAddress = restaurantForRegisterDto.RestaurantAddress,
                RestaurantName= restaurantForRegisterDto.RestaurantName,
                TaxNumber = restaurantForRegisterDto.TaxNumber,
                RestaurantRate=0,
                RegisterDate=restaurantForRegisterDto.RegisterDate
            };

            _restaurantService.Add(restaurant);
            var restaurantForDefaultOperationClaim = _restaurantService.GetByMail(restaurant.MailAddress);
            if (restaurantForDefaultOperationClaim.Success)
            {
                var defaultClaim = _operationClaimService.GetByClaimName("restaurant");

                var restaurantOperationClaimDto = new RestaurantOperationClaimDto
                {
                    OperationClaimId = defaultClaim.Data.Id,
                    RestaurantId = restaurantForDefaultOperationClaim.Data.Id
                };

                _restaurantOperationClaimService.Add(restaurantOperationClaimDto);
            }
            return new SuccessDataResult<Restaurant>(restaurant, Messages.CustomerRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_restaurantService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult(Messages.Successful);
        }

        public IResult ChangePassword(CustomerChangePasswordDto customerChangePasswordDto)
        {
            var result = _restaurantService.GetByMail(customerChangePasswordDto.EMail);
            if (result.Data != null)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(customerChangePasswordDto.OldPassword, out passwordHash, out passwordSalt);
                if (!HashingHelper.VerifyPasswordHash(customerChangePasswordDto.OldPassword, result.Data.PasswordHash, result.Data.PasswordSalt))
                {
                    return new ErrorResult(Messages.PasswordError);
                }

                HashingHelper.CreatePasswordHash(customerChangePasswordDto.NewPassword, out byte[] newPasswordHash, out byte[] newPasswordSalt);
                result.Data.PasswordSalt = newPasswordSalt;
                result.Data.PasswordHash = newPasswordHash;
                _restaurantService.Update(result.Data);
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }
    }
}
