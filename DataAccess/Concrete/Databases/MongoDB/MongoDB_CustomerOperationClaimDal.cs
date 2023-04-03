using Castle.Core.Resource;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_CustomerOperationClaimDal : MongoDB_RepositoryBase<CustomerOperationClaim, MongoDB_Context<CustomerOperationClaim, MongoDB_CustomerOperationClaimCollection>>, ICustomerOperationClaimdal
    {
        public List<CustomerOperationClaimsEvolved> GetAllClaims()
        {
            List<CustomerOperationClaim> _customerOperationClaims = new List<CustomerOperationClaim>();
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<Customer> _customers = new List<Customer>();
            List<CustomerOperationClaimsEvolved> _customerOperationClaimsEvolved = new List<CustomerOperationClaimsEvolved>();

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                _operationClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();
            }

            using (var customers = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                _customers = customers.collection.Find<Customer>(document => true).ToList();
            }

            using (var operationClaims = new MongoDB_Context<CustomerOperationClaim, MongoDB_CustomerOperationClaimCollection>())
            {
                _customerOperationClaims = operationClaims.collection.Find<CustomerOperationClaim>(document => true).ToList();
            }


            foreach (var customerOperationClaim in _customerOperationClaims)
            {
                var currentOperationlaim = _operationClaims.Where(o => o.Id == customerOperationClaim.OperationClaimId).FirstOrDefault();
                var currentUser = _customers.Where(u => u.Id == customerOperationClaim.CustomerId).FirstOrDefault();

                if (currentUser != null && currentOperationlaim != null)
                {
                    CustomerOperationClaimsEvolved customerOperationClaimsEvolved = new CustomerOperationClaimsEvolved { Id = customerOperationClaim.Id, OperationClaim = currentOperationlaim.Name, OperationClaimId = currentOperationlaim.Id, Customer = currentUser.FirstName, CustomerId = currentUser.Id };
                    _customerOperationClaimsEvolved.Add(customerOperationClaimsEvolved);
                }

            }
            return _customerOperationClaimsEvolved;
        }
    }
}
