using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {

        private readonly IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }
        public IResult Add(UserOperationClaimDto userOperationClaimSimple)
        {
            var result = BusinessRules.Run(CheckIfUserOperationClaimExists(userOperationClaimSimple));
            if (result == null)
            {
                UserOperationClaim userOperationClaim = new UserOperationClaim();
                userOperationClaim.UserId = userOperationClaimSimple.UserId;
                userOperationClaim.OperationClaimId = userOperationClaimSimple.OperationClaimId;
                _userOperationClaimDal.Add(userOperationClaim);
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(result.Message);
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimDal.Delete(userOperationClaim);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), Messages.Successful);
        }

        public IDataResult<List<UserOperationClaimsEvolved>> GetAllClaims()
        {
            return new SuccessDataResult<List<UserOperationClaimsEvolved>>(_userOperationClaimDal.GetAllClaims(), Messages.Successful);
        }

        public IDataResult<UserOperationClaim> GetById(string id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(p => p.Id == id), Messages.Successful);
        }

        public IDataResult<List<UserClaimDetailsDto>> GetClaimDetails()
        {
            return new SuccessDataResult<List<UserClaimDetailsDto>>(_userOperationClaimDal.GetClaimDetails(), Messages.Successful);
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimDal.Update(userOperationClaim);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }


        //Busines Rules

        private IResult CheckIfUserOperationClaimExists(UserOperationClaimDto userOperationClaimSimple)
        {
            var result = _userOperationClaimDal.GetAll(p => p.UserId == userOperationClaimSimple.UserId && p.OperationClaimId == userOperationClaimSimple.OperationClaimId).Any();
            if (result)
            {
                return new ErrorResult(Messages.ThisOperationClaimAlreadyExists);
            }
            return new SuccessResult(Messages.Successful);
        }
    }
}
