using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using Entities.Dtos;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserDetailsDto> GetAllUser();
        UserDto GetUserById(string id);
        List<UserEvolved> GetAllWithClaims();
        List<OperationClaim> GetClaims(User user);
        UserEvolved GetWithClaims(string userId);
        void DeleteClaims(User user);
    }
}
