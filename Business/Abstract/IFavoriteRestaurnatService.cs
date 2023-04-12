using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFavoriteRestaurnatService
    {
        IResult Add(FavoriteRestaurant favouritere);
        IResult Delete(string id);
        IResult Update(FavoriteRestaurant favouritere);
        IDataResult <List<FavoriteRestaurant>> GetAll();
        IDataResult<List<FavoriteRestaurantDto>> GetFavoriteRestaurantsByCustomerId(string id);
        IDataResult<FavoriteRestaurant> GetById(string id);
    }
}
