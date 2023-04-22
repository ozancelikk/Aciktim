using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerAddressService
    {
        IResult Add(CustomerAddresses customerAddress);
        IResult Update(CustomerAddresses customerAddress);
        IResult Delete(string id);
        IDataResult<CustomerAddresses> GetById(string id);
        IDataResult<List<CustomerAddressesDto>> GetAll();
        IDataResult<List<CustomerAddresses>> GetAllByCustomerId(string customerId);
    }
}
