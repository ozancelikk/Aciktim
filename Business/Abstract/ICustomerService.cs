using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetByMail(string mail);
        IResult ChangeForgottenPassword(Customer customer);
        IDataResult<List<OperationClaim>> GetClaims(Customer customer);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(string id);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(string id);
    }
}
