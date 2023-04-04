﻿using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
        List<CustomerDto> GetAllCustomer();
        CustomerDetailsDto GetCustomerById(string id);
        List<CustomerEvolved> GetAllWithClaims();
        List<OperationClaim> GetClaims(Customer customer);
        CustomerEvolved GetWithClaims(string customerId);
        void DeleteClaims(Customer customer);
    }
}
