using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RestaurantManager : IRestaurantService
    {
        private readonly IRestaurantDal _restaurantDal;
        public RestaurantManager(IRestaurantDal restaurantDal)
        {
            _restaurantDal = restaurantDal;
        }
        public IResult Add(Restaurant restaurant)
        {
            _restaurantDal.Add(restaurant);
            return new SuccessResult();
        }

        public IResult Delete(string id)
        {
            var restaurant = GetById(id);
            if (restaurant.Data == null)
            {
                return new ErrorResult();
            }
            var result = _restaurantDal.Delete(restaurant.Data);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<Restaurant>> GetAll()
        {
            return new SuccessDataResult<List<Restaurant>>(_restaurantDal.GetAll());
        }

        public IDataResult<Restaurant> GetById(string id)
        {
            return new SuccessDataResult<Restaurant>(_restaurantDal.Get(r => r.Id == id));
        }

        public IResult Update(Restaurant restaurant)
        {
            var result = _restaurantDal.Update(restaurant);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult();
            }
            throw new FormatException();
        }
    }
}
