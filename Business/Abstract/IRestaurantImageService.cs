using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRestaurantImageService
    {
        IResult Add(IFormFile file, RestaurantImage restaurantImage);
        IResult Delete(RestaurantImage restaurantImage);
        IResult Update(IFormFile file, RestaurantImage restaurantImage);
        IDataResult<List<RestaurantImage>> GetAll();
        IDataResult<RestaurantImage> GetByImageId(string id);
        IDataResult<List<RestaurantImage>> GetByImagesByRestaurantId(string restaurantId);
    }
}
