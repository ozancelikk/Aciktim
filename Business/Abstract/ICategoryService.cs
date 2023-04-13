using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Delete(string id);
        IResult Update(Category category);
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(string id);
        IDataResult<List<CategoryImageDto>> GetAllWithImages();
    }
}
