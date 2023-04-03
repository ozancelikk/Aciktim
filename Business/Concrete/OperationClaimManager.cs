using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {

        private readonly IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IResult AddClaim(OperationClaimDto claim)
        {
            _operationClaimDal.Add(new OperationClaim { AuthorizationRate = claim.AuthorizationRate, Description = claim.Description, Name = claim.Name });
            return new SuccessResult(Messages.Successful);
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.Successful);
        }

        public IDataResult<OperationClaim> GetByClaimName(string claimName)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(c => c.Name == claimName), Messages.Successful);
        }
    }
}
