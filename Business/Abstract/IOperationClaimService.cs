using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IResult AddClaim(OperationClaimDto claim);
        IDataResult<List<OperationClaim>> GetAll();
        IDataResult<OperationClaim> GetByClaimName(string claimName);
    }
}
