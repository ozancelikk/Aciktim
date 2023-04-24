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
    public class RestaurantCommentManager : IRestaurantCommentService
    {
        private readonly IRestaurantCommentDal _restaurantCommentDal;

        public RestaurantCommentManager(IRestaurantCommentDal restaurantCommentDal)
        {
            _restaurantCommentDal = restaurantCommentDal;
        }

        public IResult Add(RestaurantComment restaurantComment)
        {
            _restaurantCommentDal.Add(restaurantComment);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(string id)
        {
            var restaurantComment = GetById(id);
            if (restaurantComment.Data == null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _restaurantCommentDal.Delete(restaurantComment.Data);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<List<RestaurantComment>> GetAll()
        {
            return new SuccessDataResult<List<RestaurantComment>>(_restaurantCommentDal.GetAll(), Messages.Successful);
        }

        public IDataResult<RestaurantComment> GetById(string id)
        {
            return new SuccessDataResult<RestaurantComment>(_restaurantCommentDal.Get(c => c.Id == id), Messages.Successful);
        }

        public IDataResult<List<RestaurantCommentDetailsDto>> GetCommentByRestaurantId(string restaurantId)
        {
            return new SuccessDataResult<List<RestaurantCommentDetailsDto>>(_restaurantCommentDal.GetCommentByRestaurantId(restaurantId), Messages.Successful);
        }

        public IResult Update(RestaurantComment restaurantComment)
        {
            var result = _restaurantCommentDal.Update(restaurantComment);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.Unsuccessful);
        }
    }
}
