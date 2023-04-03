using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.Concrete.Simples;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
        List<CustomerEvolved> GetAllWithClaims();
        List<OperationClaim> GetClaims(Customer customer);
        CustomerEvolved GetWithClaims(string customerId);
        void DeleteClaims(Customer customer);
    }
}
