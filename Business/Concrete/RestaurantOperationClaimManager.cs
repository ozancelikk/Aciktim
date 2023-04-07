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
    public class RestaurantOperationClaimManager : IRestaurantOperationClaimService
    {

        private readonly IRestaurantOperationClaimDal _restaurantOperationClaimDal;

        public RestaurantOperationClaimManager(IRestaurantOperationClaimDal restaurantOperationClaimDal)
        {
            _restaurantOperationClaimDal = restaurantOperationClaimDal;
        }

        public IResult Add(RestaurantOperationClaimDto restaurantOperationClaimSimple)
        {
            var result = BusinessRules.Run(CheckIfUserOperationClaimExists(restaurantOperationClaimSimple));
            if (result == null)
            {
                RestaurantOperationClaim restaurantOperationClaim = new RestaurantOperationClaim();
                restaurantOperationClaim.RestaurantId = restaurantOperationClaimSimple.RestaurantId;
                restaurantOperationClaim.OperationClaimId = restaurantOperationClaimSimple.OperationClaimId;
                _restaurantOperationClaimDal.Add(restaurantOperationClaim);
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(result.Message);
        }

        public IResult Delete(RestaurantOperationClaim restaurantOperationClaimSimple)
        {
            var result = _restaurantOperationClaimDal.Delete(restaurantOperationClaimSimple);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }

        public IDataResult<List<RestaurantOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<RestaurantOperationClaim>>(_restaurantOperationClaimDal.GetAll(), Messages.Successful);
        }

        public IDataResult<List<RestaurantOperationClaimsEvolved>> GetAllClaims()
        {
            return new SuccessDataResult<List<RestaurantOperationClaimsEvolved>>(_restaurantOperationClaimDal.GetAllClaims(), Messages.Successful);
        }

        public IDataResult<RestaurantOperationClaim> GetById(string id)
        {
            return new SuccessDataResult<RestaurantOperationClaim>(_restaurantOperationClaimDal.Get(p => p.Id == id), Messages.Successful);
        }

        public IDataResult<List<RestaurantClaimDetailsDto>> GetClaimDetails()
        {
            return new SuccessDataResult<List<RestaurantClaimDetailsDto>>(_restaurantOperationClaimDal.GetClaimDetails(), Messages.Successful); 
        }

        public IResult Update(RestaurantOperationClaim restaurantOperationClaimSimple)
        {
            var result = _restaurantOperationClaimDal.Update(restaurantOperationClaimSimple);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }


        //Business Rules

        private IResult CheckIfUserOperationClaimExists(RestaurantOperationClaimDto restaurantOperationClaimSimple)
        {
            var result = _restaurantOperationClaimDal.GetAll(p => p.RestaurantId == restaurantOperationClaimSimple.RestaurantId && p.OperationClaimId == restaurantOperationClaimSimple.OperationClaimId).Any();
            if (result)
            {
                return new ErrorResult(Messages.ThisOperationClaimAlreadyExists);
            }
            return new SuccessResult(Messages.Successful);
        }
    }
}
