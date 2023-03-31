using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            return new SuccessResult();
        }

        public IResult Delete(string id)
        {
            var category=GetById(id);
            if (category.Data==null)
            {
                return new ErrorResult();
            }
            var result = _categoryDal.Delete(category.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(string id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.Id==id));
        }

        public IResult Update(Category category)
        {
            var result=_categoryDal.Update(category);
            if (result.MatchedCount>0)
            {
                return new SuccessResult();
            }
            throw new FormatException();
        }
    }
}
