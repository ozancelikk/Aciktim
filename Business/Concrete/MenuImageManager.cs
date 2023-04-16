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
    public class MenuImageManager : IMenuImageService
    {
        private readonly IMenuImageDal _menuImageDal;
        private readonly IFileHelper _fileHelper;

        public MenuImageManager(IMenuImageDal menuImageDal, IFileHelper fileHelper)
        {
            _menuImageDal = menuImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, MenuImage menuImage)
        {
            menuImage.ImagePath = _fileHelper.Upload(file, PathConstant.MenuImagesPath + menuImage.MenuId + "\\");
            _menuImageDal.Add(menuImage);
            return new SuccessResult(Messages.Successful);
        }

        public IResult Delete(MenuImage menuImage)
        {
            _fileHelper.Delete(PathConstant.MenuImagesPath + menuImage.MenuId + "\\" + menuImage.ImagePath);
            _menuImageDal.Delete(menuImage);
            return new SuccessResult();
        }

        public IDataResult<List<MenuImage>> GetAll()
        {
            return new SuccessDataResult<List<MenuImage>>(_menuImageDal.GetAll(), Messages.Successful);
        }

        public IDataResult<MenuImage> GetByImageId(string id)
        {
            return new SuccessDataResult<MenuImage>(_menuImageDal.Get(x => x.Id == id), Messages.Successful);
        }

        public IDataResult<List<MenuImage>> GetImagesByMenuId(string menuId)
        {
            return new SuccessDataResult<List<MenuImage>>(_menuImageDal.GetAll(x => x.MenuId == menuId), Messages.Successful);
        }

        public IResult Update(IFormFile file, MenuImage menuImage)
        {
            menuImage.ImagePath = _fileHelper.Update(file, PathConstant.RestaurantImagesPath + menuImage.MenuId + "\\" + menuImage.ImagePath, PathConstant.MenuImagesPath + menuImage.MenuId + "\\");
            _menuImageDal.Update(menuImage);
            return new SuccessResult();
        }
    }
}
