using Business.Abstract;
using Business.Constants;
using Castle.Core.Resource;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
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
        public IDataResult<string> AddRestaurantWithImage(Restaurant restaurant)
        {
            _restaurantDal.Add(restaurant);
            return new SuccessDataResult<string>(restaurant.Id, Messages.Successful);
        }

        public IResult ChangeForgottenPassword(Restaurant restaurant)
        {
            _restaurantDal.Update(restaurant);
            return new SuccessResult(Messages.Successful);
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

        public IDataResult<List<RestaurantImageDetailDto>> GetActiveRestaurantsWithImages()
        {
            return new SuccessDataResult<List<RestaurantImageDetailDto>>(_restaurantDal.GetActiveRestaurantsWithImages(), Messages.Successful);
        }

        public IDataResult<List<RestaurantDto>> GetAll()
        {
            return new SuccessDataResult<List<RestaurantDto>>(_restaurantDal.GetAllRestaurant(), Messages.Successful);
        }

        public IDataResult<List<RestaurantImageDetailDto>> GetAllWithImages()
        {
            return new SuccessDataResult<List<RestaurantImageDetailDto>>(_restaurantDal.GetAllRestaurantWithImages(), Messages.Successful);
        }

        public IDataResult<Restaurant>GetById(string id)
        {
            return new SuccessDataResult<Restaurant>(_restaurantDal.Get(r => r.Id == id), Messages.Successful);
        }

        public IDataResult<Restaurant> GetByMail(string mail)
        {
            return new SuccessDataResult<Restaurant>(_restaurantDal.Get(c => c.MailAddress == mail), Messages.Successful);
        }

        public IDataResult<List<OperationClaim>> GetClaims(Restaurant restaurant)
        {
            return new SuccessDataResult<List<OperationClaim>>(_restaurantDal.GetClaims(restaurant), Messages.Successful);
        }

        public IDataResult<RestaurantDetailsDto> GetDetailsById(string id)
        {
            return new SuccessDataResult<RestaurantDetailsDto>(_restaurantDal.GetRestaurantById(id), Messages.Successful);  
        }

        public IDataResult<List<RestaurantImageDetailDto>> GetPassiveRestaurantsWithImages()
        {
            return new SuccessDataResult<List<RestaurantImageDetailDto>>(_restaurantDal.GetPassiveRestaurantsWithImages(), Messages.Successful);
        }

        public IDataResult<RestaurantImageDetailDto> GetRestaurantDetailByRestaurantId(string restaurantId)
        {
            return new SuccessDataResult<RestaurantImageDetailDto>(_restaurantDal.GetRestaurantDetailImagesById(restaurantId), Messages.Successful);
        }

        public IDataResult<List<RestaurantImageDetailDto>> GetRestaurantsByCategoryId(params string[] categoryId)
        {
            return new SuccessDataResult<List<RestaurantImageDetailDto>>(_restaurantDal.GetRestaurantsByCategoryId(categoryId), Messages.Successful);
        }

        public IDataResult<List<RestaurantOrderDto>> GetRestaurantsOrderNumber()
        {
            return new SuccessDataResult<List<RestaurantOrderDto>>(_restaurantDal.GetRestaurantsOrderNumber(), Messages.Successful);
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
