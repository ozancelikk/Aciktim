using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRestaurantCommentService
    {
        IDataResult<List<RestaurantComment>> GetAll();
        IDataResult<RestaurantComment> GetById(string id);
        IResult Add(RestaurantComment  restaurantComment);
        IResult Update(RestaurantComment restaurantComment);
        IResult Delete(string id);
        IDataResult<List<RestaurantCommentDetailsDto>> GetCommentByRestaurantId(string restaurantId);
    }
}
