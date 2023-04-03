using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RestaurantAuthManager : IRestaurantAuthService
    {
        public IResult ChangeForgottenPassword(ForgettenPasswordForRestaurant forgettenPasswordForRestaurant)
        {
            throw new NotImplementedException();
        }

        public IDataResult<AccessToken> CreateAccessToken(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public IResult ForgotPassword(string eMail)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(RestaurantForLoginDto restaurantForLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Restaurant> Register(RestaurantForRegisterDto restaurantForRegisterDto)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
