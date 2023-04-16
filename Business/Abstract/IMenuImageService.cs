using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMenuImageService
    {
        IResult Add(IFormFile file, MenuImage menuImage);
        IResult Delete(MenuImage menuImage);
        IResult Update(IFormFile file, MenuImage menuImage);
        IDataResult<List<MenuImage>> GetAll();
        IDataResult<MenuImage> GetByImageId(string id);
        IDataResult<List<MenuImage>> GetImagesByMenuId(string menuId);
    }
}
