using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryImageService
    {
        IResult Add(IFormFile file, CategoryImage categoryImage);
        IResult Delete(CategoryImage categoryImage);
        IResult Update(IFormFile file, CategoryImage categoryImage);
        IDataResult<List<CategoryImage>> GetAll();
        IDataResult<CategoryImage> GetByImageId(string id);
        IDataResult<List<CategoryImage>> GetByImagesByCategoryId(string categoryId);
    }
}
