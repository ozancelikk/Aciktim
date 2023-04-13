using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryImageManager : ICategoryImageService
    {
        private readonly ICategoryImageDal _categoryImageDal;
        private readonly IFileHelper _fileHelper;
        public CategoryImageManager(ICategoryImageDal categoryImageDal, IFileHelper fileHelper)
        {
            _categoryImageDal = categoryImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CategoryImage categoryImage)
        {
            categoryImage.ImagePath = _fileHelper.Upload(file, PathConstant.CategoryImagesPath + categoryImage.CategoryId + "\\");
            _categoryImageDal.Add(categoryImage);
            return new SuccessResult(Messages.Successful);
        }

        public IResult Delete(CategoryImage categoryImage)
        {
            _fileHelper.Delete(PathConstant.RestaurantImagesPath + categoryImage.CategoryId + "\\" + categoryImage.ImagePath);
            _categoryImageDal.Delete(categoryImage);
            return new SuccessResult();
        }

        public IDataResult<List<CategoryImage>> GetAll()
        {
            return new SuccessDataResult<List<CategoryImage>>(_categoryImageDal.GetAll(), Messages.Successful);
        }

        public IDataResult<CategoryImage> GetByImageId(string id)
        {
            return new SuccessDataResult<CategoryImage>(_categoryImageDal.Get(x => x.Id == id), Messages.Successful);
        }

        public IDataResult<List<CategoryImage>> GetByImagesByCategoryId(string categoryId)
        {
            return new SuccessDataResult<List<CategoryImage>>(_categoryImageDal.GetAll(x => x.CategoryId == categoryId), Messages.Successful);
        }

        public IResult Update(IFormFile file, CategoryImage categoryImage)
        {
            categoryImage.ImagePath = _fileHelper.Update(file, PathConstant.RestaurantImagesPath + categoryImage.CategoryId + "\\" + categoryImage.ImagePath, PathConstant.CategoryImagesPath + categoryImage.CategoryId + "\\");
            _categoryImageDal.Update(categoryImage);
            return new SuccessResult();
        }
    }
}
