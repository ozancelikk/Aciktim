using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerOperationClaimdal:IEntityRepository<CustomerOperationClaim>
    {
        List<CustomerOperationClaimsEvolved> GetAllClaims();
        List<CustomerClaimsDetailsDto> GetCustomerClaims(string id);
    }
}
