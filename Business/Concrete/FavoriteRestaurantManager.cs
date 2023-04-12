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
    public class FavoriteRestaurantManager : IFavoriteRestaurnatService
    {
        private readonly IFavoriteRestaurantDal _favoriteRestaurantDal;

        public FavoriteRestaurantManager(IFavoriteRestaurantDal favoriteRestaurantDal)
        {
            _favoriteRestaurantDal = favoriteRestaurantDal;
        }

        public IResult Add(FavoriteRestaurant favouritere)
        {
            _favoriteRestaurantDal.Add(favouritere);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(string id)
        {
            var favorite = GetById(id);
            if (favorite.Data == null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _favoriteRestaurantDal.Delete(favorite.Data);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.AddingSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<List<FavoriteRestaurant>> GetAll()
        {
            return new SuccessDataResult<List<FavoriteRestaurant>>(_favoriteRestaurantDal.GetAll(),Messages.Successful);
        }

        public IDataResult<FavoriteRestaurant> GetById(string id)
        {
            return new SuccessDataResult<FavoriteRestaurant>(_favoriteRestaurantDal.Get(f=>f.Id==id));
        }

        public IDataResult<List<FavoriteRestaurantDto>> GetFavoriteRestaurantsByCustomerId(string id)
        {
            return new SuccessDataResult<List<FavoriteRestaurantDto>>(_favoriteRestaurantDal.GetAllFavoriteRestaurant(id),Messages.Successful);
        }

        public IResult Update(FavoriteRestaurant favouritere)
        {
            throw new NotImplementedException();
        }

    }
}
