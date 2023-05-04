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
        IDataResult<Restaurant> Login(RestaurantForLoginDto restaurantForLoginDto);
        IResult UserExists(string email);
        IDataResult<RestaurantAccessToken> CreateAccessToken(Restaurant restaurant);
        IResult ForgotPassword(string eMail);
        IResult ChangeForgottenPassword(ForgettenPasswordForRestaurant forgettenPasswordForRestaurant);
        IResult ChangePassword(CustomerChangePasswordDto customerChangePasswordDto);
    }
}
