using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(string id)
        {
            var restaurant = GetById(id);
            if (restaurant.Data == null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _restaurantDal.Delete(restaurant.Data);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<List<Restaurant>> GetAll()
        {
            return new SuccessDataResult<List<Restaurant>>(_restaurantDal.GetAll(), Messages.Successful);
        }

        public IDataResult<Restaurant> GetById(string id)
        {
            return new SuccessDataResult<Restaurant>(_restaurantDal.Get(r => r.Id == id), Messages.Successful);
        }

        public IResult Update(Restaurant restaurant)
        {
            var result = _restaurantDal.Update(restaurant);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.Unsuccessful);
        }
    }
}
