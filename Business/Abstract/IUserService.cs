using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Concrete.Simples;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<UserDetailsDto>> GetAll();
        IDataResult<UserDto> GetDetailsById(string id); 
        IResult Add(User user);
        IResult Delete(User user); 
        IDataResult<UserEvolved> GetById(string id);
        IDataResult<User> GetByMail(string email); 
        IDataResult<UserDto> Update(UserDto user);   
        IResult ChangePassword(UserForChangePasswordDto userForRegisterDto);
        IResult ChangeForgottenPassword(User user);
    }
}
