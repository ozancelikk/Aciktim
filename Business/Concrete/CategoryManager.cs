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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal= categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(string id)
        {
            var category=GetById(id);
            if (category.Data==null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _categoryDal.Delete(category.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.Successful);
        }

        public IDataResult<List<CategoryImageDto>> GetAllWithImages()
        {
            return new SuccessDataResult<List<CategoryImageDto>>(_categoryDal.GetAllCategoriesWithImages(), Messages.Successful);
        }

        public IDataResult<Category> GetById(string id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.Id==id), Messages.Successful);
        }

        public IResult Update(Category category)
        {
            var result=_categoryDal.Update(category);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.Unsuccessful);
        }
    }
}
