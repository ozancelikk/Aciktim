using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRestaurantService
    {
        IDataResult<List<Restaurant>> GetAll();
        IDataResult<Restaurant> GetById(string id);
        IResult Add(Restaurant restaurant);
        IResult Update(Restaurant restaurant);
        IResult Delete(string id);
        IDataResult<Restaurant> GetByMail(string mail);
        IResult ChangeForgottenPassword(Restaurant restaurant);
        IDataResult<List<OperationClaim>> GetClaims(Restaurant restaurant);
    }
}
