using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(UserExists(user.Email));

            if (result != null)
            {
                return result;
            }
            _userDal.Add(user);

            return new SuccessResult(Messages.Successful);
        }

        public IResult ChangeForgottenPassword(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Successful);
        }

        public IResult ChangePassword(UserForChangePasswordDto userForRegisterDto)
        {
            var userToCheck = GetByMail(userForRegisterDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForRegisterDto.OldPassword, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(userForRegisterDto.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

            userToCheck.Data.PasswordHash = passwordHash;
            userToCheck.Data.PasswordSalt = passwordSalt;
            var result = _userDal.Update(userToCheck.Data);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            return new ErrorResult(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }

        public IResult Delete(User user)
        {
            var claims = GetClaims(user);
            var claim = claims.Data.Find(c => c.Name == "suser");
            if (claim == null)
            {
                var result = _userDal.Delete(user);
                if (result.DeletedCount > 0)
                {
                    _userDal.DeleteClaims(user);

                    return new SuccessResult(Messages.Successful);
                }
                throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);

            }
            return new ErrorResult(Messages.SuperUserCannotBeDeleted);
        }

        public IDataResult<List<UserDetailsDto>> GetAll()
        {
            return new SuccessDataResult<List<UserDetailsDto>>(_userDal.GetAllUser(), Messages.Successful);
        }

        public IDataResult<UserEvolved> GetById(string id)
        {
            return new SuccessDataResult<UserEvolved>(_userDal.GetWithClaims(id), Messages.Successful);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.Successful);
        }

        public IDataResult<UserDto> GetDetailsById(string id)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUserById(id), Messages.Successful);
        }

        public IDataResult<UserDto> Update(UserDto user)
        {
            var currentUser = GetByMail(user.Email);
            currentUser.Data.Email = user.Email;
            currentUser.Data.FirstName = user.FirstName;
            currentUser.Data.LastName = user.LastName;
            currentUser.Data.Status = user.Status;

            var result = _userDal.Update(currentUser.Data);
            if (result.MatchedCount > 0)
            {
                return new SuccessDataResult<UserDto>(user, Messages.UserUpdated);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }


        //Business Rules

        private IResult UserExists(string email)
        {
            var result = GetByMail(email);
            if (result.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult(Messages.Successful);
        }
    }
}
