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
    public class SupportManager : ISupportService
    {

        private readonly ISupportDal _supportDal;

        public SupportManager(ISupportDal supportDal)
        {
            _supportDal = supportDal;
        }

        public IResult Add(Support support)
        {
            _supportDal.Add(support);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(string id)
        {
            var menu = GetById(id);
            if (menu.Data == null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _supportDal.Delete(menu.Data);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.AddingSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<List<Support>> GetAll()
        {
            return new SuccessDataResult<List<Support>>(_supportDal.GetAll(), Messages.Successful);
        }

        public IDataResult<Support> GetById(string id)
        {
            return new SuccessDataResult<Support>(_supportDal.Get(m => m.Id == id), Messages.Successful);
        }

        public IDataResult<List<SupportListDto>> GetSupportDetails()
        {
            return new SuccessDataResult<List<SupportListDto>>(_supportDal.GetSupportDetails(), Messages.Successful);
        }

        public IDataResult<SupportListDto> GetSupportDetailsById(string id)
        {
            return new SuccessDataResult<SupportListDto>(_supportDal.GetSupportDetailsById(id), Messages.Successful);
        }

        public IResult Update(Support support)
        {
            var result = _supportDal.Update(support);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.Unsuccessful);
        }
    }
}
