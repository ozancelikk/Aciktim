using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRestaurantAuthService
    {
        IDataResult<Restaurant> Register(RestaurantForRegisterDto restaurantForRegisterDto);
        IDataResult<User> Login(RestaurantForLoginDto restaurantForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Restaurant restaurant);
        IResult ForgotPassword(string eMail);
        IResult ChangeForgottenPassword(ForgettenPasswordForRestaurant forgettenPasswordForRestaurant);
    }
}
