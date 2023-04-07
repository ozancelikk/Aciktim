using AutoMapper;
using Castle.Core.Resource;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_CustomerOperationClaimDal : MongoDB_RepositoryBase<CustomerOperationClaim, MongoDB_Context<CustomerOperationClaim, MongoDB_CustomerOperationClaimCollection>>, ICustomerOperationClaimdal
    {
        private readonly IMapper _mapper;

        public MongoDB_CustomerOperationClaimDal(IMapper mapper)
        {
            _mapper = mapper;
        }

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
        public List<CustomerClaimsDetailsDto> GetCustomerClaims(string id)
        {
            List<Customer> customer = new List<Customer>();
            List<CustomerOperationClaim> _customerOperationClaim = new List<CustomerOperationClaim>();
            List<CustomerClaimsDetailsDto> dtos = new List<CustomerClaimsDetailsDto>();

            using (var customers = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customers.GetMongoDBCollection();
                customer = customers.collection.Find<Customer>(document => true).ToList();
            }
            List<OperationClaim> claims = new List<OperationClaim>();
            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                claims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();
            }

            List<OperationClaim> _currentUserOperationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<CustomerOperationClaim, MongoDB_CustomerOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _customerOperationClaim = operationClaims.collection.Find<CustomerOperationClaim>(document => true).ToList();
            }
            var customerOperationClaims = _customerOperationClaim.Where(u => u.CustomerId == id).ToList();   // kullanıcının rollerini tutuyor


            foreach (var userOperationClaim in customerOperationClaims)
            {
                var temp = customer.Find(x => x.Id == userOperationClaim.CustomerId);       // current customer
                var claimName = claims.Find(x => x.Id == userOperationClaim.OperationClaimId);

                var result = _mapper.Map<CustomerClaimsDetailsDto>(temp);
                result.Mail = temp.MailAddress;
                result.ClaimName = claimName.Name;
                dtos.Add(result);
            }
            return dtos;
        }
    }
}
