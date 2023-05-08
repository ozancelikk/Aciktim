using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Dtos;
using Entities.DTOs;
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
        IDataResult<List<CustomerDto>> GetAll();
        IDataResult<List<CustomerDetailsDto>> GetAllWithId();
        IDataResult<Customer> GetById(string id);
        IDataResult<CustomerDetailsDto> GetDetailsById(string id);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(string id);
        IDataResult<CustomerDto> GetCustomerDetailsByMail(string mail);
        IDataResult<List<CustomerOrdersByOrderNumberDto>> GetCustomerOrdersByOrderNumbers();
        IDataResult<int> GetCustomersByTodayRegisterDate();

    }
}
