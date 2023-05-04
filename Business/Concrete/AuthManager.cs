using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IOperationClaimService _operationClaimService;
        private readonly ILoginActivitiesService _loginActivitiesService;
        private readonly IPasswordRecoveryService _passwordRecoveryService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService, IOperationClaimService operationClaimService, ILoginActivitiesService loginActivitiesService, IPasswordRecoveryService passwordRecoveryService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
            _operationClaimService = operationClaimService;
            _loginActivitiesService = loginActivitiesService;
            _passwordRecoveryService = passwordRecoveryService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = false
            };

            _userService.Add(user);
            var userForDefaultOperationClaim = _userService.GetByMail(user.Email);
            if (userForDefaultOperationClaim.Success)
            {
                var defaultClaim = _operationClaimService.GetByClaimName("admin");

                var userOperationClaim = new UserOperationClaimDto
                {
                    OperationClaimId = defaultClaim.Data.Id,
                    UserId = userForDefaultOperationClaim.Data.Id
                };

                _userOperationClaimService.Add(userOperationClaim);
            }


            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }


        //[ValidationAspect(typeof(AuthValidatorForLogin))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null || !userToCheck.Data.Status)
            {
                return new ErrorDataResult<User>(Messages.MissingOrIncorrectEntry);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                //_loginActivities.Add(new LoginActivities { DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), User = userForLoginDto.Email, Type = "Login Failed" });
                return new ErrorDataResult<User>(Messages.MissingOrIncorrectEntry);
            }
            //_loginActivities.Add(new LoginActivities { DateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), User = userForLoginDto.Email, Type = "Login Success" });
            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        //[BusinessForgotPasswordAspect]
        public IResult ForgotPassword(string eMail)
        {
            var result = _userService.GetByMail(eMail);
            if (result.Data != null)
            {
                return new SuccessResult(eMail + " mail adresine aktivasyon kodu gönderdik. Lüften mail adresinizi kontrol ederek gelen kodu aşağıdaki alana giriniz.");
            }
            return new ErrorResult("Eksik yada hatalı bir giriş yaptınız.");
        }

        public IResult ChangeForgottenPassword(ForgottenPassword forgottenPassword)
        {
            var result = _passwordRecoveryService.GetByEMail(forgottenPassword.Email);

            if (result.Data != null)
            {
                if (result.Data.PrivateKey != forgottenPassword.PrivateKey)
                {
                    return new ErrorResult("Yanlış aktivasyon kodu girdiniz.");
                }
                var user = _userService.GetByMail(forgottenPassword.Email);
                HashingHelper.CreatePasswordHash(forgottenPassword.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
                user.Data.PasswordSalt = passwordSalt;
                user.Data.PasswordHash = passwordHash;
                _userService.ChangeForgottenPassword(user.Data);
                _passwordRecoveryService.Delete(user.Data.Email);
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult(Messages.Successful);
        }

        public IDataResult<UserAccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateTokenForUser(user, claims.Data);
            return new SuccessDataResult<UserAccessToken>(accessToken, Messages.AccessTokenCreated);
        }
         
    }
}
