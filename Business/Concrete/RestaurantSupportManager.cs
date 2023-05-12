using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RestaurantSupportManager : IRestaurantSupportService
    {
        private IRestaurantSupportDal _restaurantSupport;

        public RestaurantSupportManager(IRestaurantSupportDal restaurantSupport)
        {
            _restaurantSupport = restaurantSupport;
        }

        public IResult Add(RestaurantSupport restaurantSupport)
        {
            _restaurantSupport.Add(restaurantSupport);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(string id)
        {
            var result = _restaurantSupport.Delete(id);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.Successful);
            }
            throw new FormatException(Messages.AnErrorOccurredDuringTheDeleteProcess);
        }

        public IDataResult<List<RestaurantSupport>> GetAll()
        {
            return new SuccessDataResult<List<RestaurantSupport>>(_restaurantSupport.GetAll(), Messages.Successful);
        }

        public IDataResult<RestaurantSupport> GetById(string id)
        {
            return new SuccessDataResult<RestaurantSupport>(_restaurantSupport.Get(c => c.Id == id), Messages.Successful);
        }

        public IDataResult<List<RestaurantSupportListDto>> GetMailDetails()
        {
            return new SuccessDataResult<List<RestaurantSupportListDto>>(_restaurantSupport.GetMailDetails(), Messages.Successful);
        }

        public IDataResult<RestaurantSupportListDto> GetMailDetailsByRestaurantId(string id)
        {
            return new SuccessDataResult<RestaurantSupportListDto>(_restaurantSupport.GetMailDetailsByRestaurantId(id), Messages.Successful);
        }
    }
}
