using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MenuManager : IMenuService
    {
        private readonly IMenuDal _menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            _menuDal= menuDal;
        }
        public IResult Add(Menu menu)
        {
            _menuDal.Add(menu);
            return new SuccessResult();
        }

        public IResult Delete(string id)
        {
            var menu=GetById(id);
            if (menu.Data==null)
            {
                return new ErrorResult();
            }
            var result = _menuDal.Delete(menu.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<Menu>> GetAll()
        {
            return new SuccessDataResult<List<Menu>>(_menuDal.GetAll());
        }

        public IDataResult<Menu> GetById(string id)
        {
            return new SuccessDataResult<Menu>(_menuDal.Get(m=>m.Id==id));
        }

        public IResult Update(Menu menu)
        {
            var result=_menuDal.Update(menu);
            if (result.MatchedCount>0)
            {
                return new SuccessResult();
            }
            throw new FormatException();
        }
    }
}
