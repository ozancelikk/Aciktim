using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRestaurantOperationClaimService
    {
        IDataResult<RestaurantOperationClaim> GetById(string id);
        IDataResult<List<RestaurantOperationClaimsEvolved>> GetAllClaims();
        IDataResult<List<RestaurantOperationClaim>> GetAll();
        IDataResult<List<RestaurantClaimDetailsDto>> GetClaimDetails();
        IResult Add(RestaurantOperationClaimDto restaurantOperationClaimSimple);
        IResult Delete(RestaurantOperationClaim restaurantOperationClaimSimple);
        IResult Update(RestaurantOperationClaim restaurantOperationClaimSimple);

    }
}
