using AutoMapper;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.Concrete.Simples;
using Entities.Dtos;
using Entities.DTOs;
using MongoDB.Driver;
using System;
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
            using (var customerContext = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customerContext.GetMongoDBCollection();
                customers = customerContext.collection.Find<Customer>(document => true).ToList();
                var customerDtos = new List<CustomerDto>();
                foreach (var customer in customers)
                {
                    if (customer.Id != null)
                    {
                        customerDtos.Add(new CustomerDto
                        {
                            BirthDay = customer.BirthDay,
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            MailAddress = customer.MailAddress,
                            NationalityId = customer.NationalityId,
                            PhoneNumber = customer.PhoneNumber,
                            RegisterDate = customer.RegisterDate,
                        });
                    }
                }
                return customerDtos;
            }
        }

        public List<CustomerDetailsDto> GetAllCustomerWithId()
        {
            List<Customer> customers = new List<Customer>();
            List<CustomerDetailsDto> myList = new List<CustomerDetailsDto>();
            using (var customerContext = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customerContext.GetMongoDBCollection();
                customers = customerContext.collection.Find<Customer>(document => true).ToList();
            }
            foreach (var item in customers)
            {
                var map = _mapper.Map<CustomerDetailsDto>(item);
                myList.Add(map);
            }
            return myList;
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

        public CustomerDto GetCustomerByMail(string mail)
        {
            using (var customerContext = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customerContext.GetMongoDBCollection();
                var customers = customerContext.collection.Find<Customer>(document => true).ToList();
                var temp = customers.Find(x => x.MailAddress == mail);
                var customer = _mapper.Map<CustomerDto>(temp);
                return customer;
            }
        }

        public List<CustomerOrdersByOrderNumberDto> GetCustomerOrdersByOrderNumbers()
        {
            List<CustomerOrdersByOrderNumberDto> list = new List<CustomerOrdersByOrderNumberDto>();
            List<Customer> customer = new List<Customer>();
            List<Order> order = new List<Order>();
            using (var customers = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customers.GetMongoDBCollection();
                customer = customers.collection.Find<Customer>(document => true).ToList();
            }

            using (var orderContext = new MongoDB_Context<Order, MongoDB_OrderCollection>())
            {
                orderContext.GetMongoDBCollection();
                order = orderContext.collection.Find<Order>(document => true).ToList();
            }

            var temp = order.GroupBy(x => x.CustomerId).ToList().OrderByDescending(x => x.Count()).Take(10).ToList();

            foreach (var group in temp)
            {
                var müsteri = customer.FirstOrDefault(x => x.Id == group.Key);
                if (customer != null)
                {
                    list.Add(new CustomerOrdersByOrderNumberDto
                    {
                        CustomerId = müsteri.Id,
                        CustomerName = müsteri.FirstName + " " + müsteri.LastName,
                        OrderNumber = group.Count()
                    });
                }
            }
            return list;
        }

        public int GetCustomersByTodayRegisterDate()
        {
            List<Customer> customers = new List<Customer>();
            int count = 0;
            using (var customerContext = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customerContext.GetMongoDBCollection();
                customers = customerContext.collection.Find<Customer>(document => true).ToList();
                foreach (var customer in customers)
                {
                    var a = customer.RegisterDate.Split('.', ' ');
                    var registerDate = a[0] + "." + a[1] + "." + a[2];
                    if(registerDate == DateTime.Today.ToString("dd.MM.yyyy"))
                    {
                        count++;
                    }
                    
                }
            }
            return count;
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
