using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerOperationClaimService
    {
        IDataResult<CustomerOperationClaim> GetById(string id);
        IDataResult<List<CustomerOperationClaimsEvolved>> GetAllClaims();
        IDataResult<List<CustomerOperationClaim>> GetAll();
        IResult Add(CustomerOperationClaimDto CustomerOperationClaimSimple);
        IResult Delete(CustomerOperationClaim CustomerOperationClaim);
        IResult Update(CustomerOperationClaim CustomerOperationClaim);
        IDataResult<List<CustomerClaimsDetailsDto>> GetCustomersClaims(string id);
    }
}
