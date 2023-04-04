using AutoMapper;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using Entities.Dtos;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_CustomerDal : MongoDB_RepositoryBase<Customer, MongoDB_Context<Customer, MongoDB_CustomerCollection>>, ICustomerDal
    {
        private readonly IMapper _mapper;

        public MongoDB_CustomerDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void DeleteClaims(Customer customer)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<CustomerOperationClaim, MongoDB_CustomerOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                operationClaims.collection.DeleteMany(c => c.CustomerId == customer.Id);

            }
        }

        public List<CustomerDto> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();
            using (var customerContext = new MongoDB_Context<Customer,MongoDB_CustomerCollection>())
            {
                customerContext.GetMongoDBCollection();
                customers=customerContext.collection.Find<Customer>(document=>true).ToList();
                var customerDtos = new List<CustomerDto>();
                foreach (var customer in customers)
                {
                    if (customer.Id!=null)
                    {
                        customerDtos.Add(new CustomerDto
                        {
                            BirthDay=customer.BirthDay,
                            Address=customer.Address,
                            FirstName=customer.FirstName,
                            LastName=customer.LastName,
                            MailAddress=customer.MailAddress,
                            NationalityId=customer.NationalityId,
                            Phonenumber=customer.Phonenumber
                        });
                    }
                }
                return customerDtos;
            }
            
        
            
        }

        public List<CustomerEvolved> GetAllWithClaims()
        {
            List<CustomerEvolved> _customerEvolveds = new List<CustomerEvolved>();
            List<Customer> _customers = new List<Customer>();
            using (var customers = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customers.GetMongoDBCollection();
                _customers = customers.collection.Find<Customer>(document => true).ToList();
            }

            foreach (var customer in _customers)
            {

                CustomerEvolved customerEvolved = new CustomerEvolved
                {
                    Id = customer.Id,
                    Email = customer.MailAddress,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    OperationClaims = GetClaims(customer)

                };
                _customerEvolveds.Add(customerEvolved);
            }

            return _customerEvolveds;
        }

        public List<OperationClaim> GetClaims(Customer customer)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<CustomerOperationClaim> _userOperationClaim = new List<CustomerOperationClaim>();
            List<OperationClaim> _currentUserOperationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();

                _operationClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();

            }

            using (var operationClaims = new MongoDB_Context<CustomerOperationClaim, MongoDB_CustomerOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _userOperationClaim = operationClaims.collection.Find<CustomerOperationClaim>(document => true).ToList();

            }


            var userOperationClaims = _userOperationClaim.Where(u => u.CustomerId == customer.Id).ToList();
            foreach (var userOperationClaim in userOperationClaims)
            {
                _currentUserOperationClaims.Add(_operationClaims.Where(oc => oc.Id == userOperationClaim.OperationClaimId).FirstOrDefault());
            }

            return _currentUserOperationClaims;
        }

        public CustomerDetailsDto GetCustomerById(string id)
        {

            using (var customerContext = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customerContext.GetMongoDBCollection();
                var customers = customerContext.collection.Find<Customer>(document => true).ToList();
                var temp = customers.Find(x => x.Id == id);
               
                var real = _mapper.Map<CustomerDetailsDto>(temp);
                return real;
            }
        }

        public CustomerEvolved GetWithClaims(string customerId)
        {
            Customer customer = new Customer();
            using (var customers = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customers.GetMongoDBCollection();
                customer = customers.collection.Find<Customer>(document => document.Id == customerId).FirstOrDefault();
            }

            CustomerEvolved customerEvolved = new CustomerEvolved
            {
                Id = customer.Id,
                Email = customer.MailAddress,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                OperationClaims = GetClaims(customer),

            };
            return customerEvolved;
        }
    }
}
