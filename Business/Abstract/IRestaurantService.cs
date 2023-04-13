﻿using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRestaurantService
    {
        IDataResult<List<RestaurantDto>> GetAll();
        IDataResult<List<RestaurantImageDetailDto>> GetAllWithImages();
        IDataResult<RestaurantImageDetailDto> GetRestaurantDetailByRestaurantId(string restaurantId);
        IDataResult<Restaurant> GetById(string id);
        IDataResult<RestaurantDetailsDto> GetDetailsById(string id);
        IResult Add(Restaurant restaurant);
        IResult Update(Restaurant restaurant);
        IResult Delete(string id);
        IDataResult<Restaurant> GetByMail(string mail);
        IResult ChangeForgottenPassword(Restaurant restaurant);
        IDataResult<List<OperationClaim>> GetClaims(Restaurant restaurant);
    }
}
