using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRestaurantSupportService
    {
        IDataResult<List<RestaurantSupport>> GetAll();
        IDataResult<RestaurantSupport> GetById(string id);
        IResult Add(RestaurantSupport restaurantSupport);
        IResult Delete(string id);
        IDataResult<RestaurantSupportListDto> GetMailDetailsByRestaurantId(string id);
        IDataResult<List<RestaurantSupportListDto>> GetMailDetails();
    }
}
