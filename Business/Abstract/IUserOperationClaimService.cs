﻿using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<UserOperationClaim> GetById(string id);
        IDataResult<List<UserOperationClaimsEvolved>> GetAllClaims();
        IDataResult<List<UserClaimDetailsDto>> GetClaimDetails();
        IDataResult<List<UserClaimDetailsDto>> GetClaimDetailsByUserId(string userId);
        IDataResult<List<UserOperationClaim>> GetAll();
        IResult Add(UserOperationClaimDto userOperationClaimSimple);
        IResult Delete(string id);
        IResult Update(UserOperationClaim userOperationClaim);
        
    }
}
