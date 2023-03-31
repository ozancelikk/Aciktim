using Core.Utilities.Results;
using Entities.Concrete;
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
    }
}
