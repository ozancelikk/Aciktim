using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RestaurantImageManager : IRestaurantImageService
    {
        private readonly IRestaurantImageDal _restaurantImageDal;
        private readonly IFileHelper _fileHelper;

        public RestaurantImageManager(IRestaurantImageDal restaurantImageDal, IFileHelper fileHelper)
        {
            _restaurantImageDal = restaurantImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, RestaurantImage restaurantImage)
        {
            restaurantImage.ImagePath = _fileHelper.Upload(file, PathConstant.RestaurantImagesPath + restaurantImage.RestaurantId + "\\");
            _restaurantImageDal.Add(restaurantImage);
            return new SuccessResult(Messages.Successful);
        }

        public IResult Update(IFormFile file, RestaurantImage restaurantImage)
        {
            restaurantImage.ImagePath = _fileHelper.Update(file, PathConstant.RestaurantImagesPath + restaurantImage.RestaurantId + "\\" + restaurantImage.ImagePath, PathConstant.RestaurantImagesPath + restaurantImage.RestaurantId + "\\");
            _restaurantImageDal.Update(restaurantImage);
            return new SuccessResult();
        }

        public IResult Delete(RestaurantImage restaurantImage)
        {
            _fileHelper.Delete(PathConstant.RestaurantImagesPath +  restaurantImage.RestaurantId + "\\" + restaurantImage.ImagePath);
            _restaurantImageDal.Delete(restaurantImage);
            return new SuccessResult();
        }

        public IDataResult<List<RestaurantImage>> GetAll()
        {
            return new SuccessDataResult<List<RestaurantImage>>(_restaurantImageDal.GetAll(), Messages.Successful);
        }

        public IDataResult<RestaurantImage> GetByImageId(string id)
        {
            return new SuccessDataResult<RestaurantImage>(_restaurantImageDal.Get(x => x.Id == id), Messages.Successful);
        }

        public IDataResult<List<RestaurantImage>> GetByImagesByRestaurantId(string restaurantId)
        {
            return new SuccessDataResult<List<RestaurantImage>>(_restaurantImageDal.GetAll(x => x.RestaurantId == restaurantId), Messages.Successful);
        }

       
    }
}
