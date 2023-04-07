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
    public class CustomerOperationClaimManager : ICustomerOperationClaimService
    {
        private readonly ICustomerOperationClaimdal _customerOperationClaimdal;

        public CustomerOperationClaimManager(ICustomerOperationClaimdal customerOperationClaimdal)
        {
            _customerOperationClaimdal = customerOperationClaimdal;
        }

        public IResult Add(CustomerOperationClaimDto CustomerOperationClaimSimple)
        {
            var result = BusinessRules.Run(CheckIfUserOperationClaimExists(CustomerOperationClaimSimple));
            if (result == null)
            {
                CustomerOperationClaim customerOperationClaim = new CustomerOperationClaim();
                customerOperationClaim.CustomerId = CustomerOperationClaimSimple.CustomerId;
                customerOperationClaim.OperationClaimId = CustomerOperationClaimSimple.OperationClaimId;
                _customerOperationClaimdal.Add(customerOperationClaim);
                return new SuccessResult(Messages.Successful);
            }
            return new ErrorResult(result.Message);
        }

        public IResult Delete(CustomerOperationClaim CustomerOperationClaim)
        {
            var result = _customerOperationClaimdal.Delete(CustomerOperationClaim);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }

        public IDataResult<List<CustomerOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<CustomerOperationClaim>>(_customerOperationClaimdal.GetAll(), Messages.Successful);
        }

        public IDataResult<List<CustomerOperationClaimsEvolved>> GetAllClaims()
        {
            return new SuccessDataResult<List<CustomerOperationClaimsEvolved>>(_customerOperationClaimdal.GetAllClaims(), Messages.Successful);
        }

        public IDataResult<CustomerOperationClaim> GetById(string id)
        {
            return new SuccessDataResult<CustomerOperationClaim>(_customerOperationClaimdal.Get(p => p.Id == id), Messages.Successful);
        }

        public IResult Update(CustomerOperationClaim CustomerOperationClaim)
        {
            var result = _customerOperationClaimdal.Update(CustomerOperationClaim);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheUpdateProcess);
        }

        public IDataResult<List<CustomerClaimsDetailsDto>> GetCustomersClaims(string id)
        {
            return new SuccessDataResult<List<CustomerClaimsDetailsDto>>(_customerOperationClaimdal.GetCustomerClaims(id), Messages.Successful);
        }

        //Busines Rules

        private IResult CheckIfUserOperationClaimExists(CustomerOperationClaimDto customerOperationClaimSimple)
        {
            var result = _customerOperationClaimdal.GetAll(p => p.CustomerId == customerOperationClaimSimple.CustomerId && p.OperationClaimId == customerOperationClaimSimple.OperationClaimId).Any();
            if (result)
            {
                return new ErrorResult(Messages.ThisOperationClaimAlreadyExists);
            }
            return new SuccessResult(Messages.Successful);
        }
    }
}
