using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICustomerAddressesDal : IEntityRepository<CustomerAddresses>
    {
        List<CustomerAddressesDto> GetAllAddresses();
        //List<CustomerAddressesDto> GetAllByCustomerId(string id);
    }
}
