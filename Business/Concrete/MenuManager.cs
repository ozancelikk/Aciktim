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
            return new SuccessResult(Messages.Successful);
        }

        public IDataResult<string> AddMenuWithImage(Menu menu)
        {
            _menuDal.Add(menu);
            return new SuccessDataResult<string>(menu.Id,Messages.Successful);
        }

        public IResult Delete(string id)
        {
            var menu=GetById(id);
            if (menu.Data==null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _menuDal.Delete(menu.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.AddingSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<List<Menu>> GetAll()
        {
            return new SuccessDataResult<List<Menu>>(_menuDal.GetAll(), Messages.Successful);
        }

        public IDataResult<Menu> GetById(string id)
        {
            return new SuccessDataResult<Menu>(_menuDal.Get(m=>m.Id==id), Messages.Successful);
        }

        public IDataResult<List<MenuDetailsDto>> GetMenusDetailsByRestaurantId(string restaurantId)
        {
            return new SuccessDataResult<List<MenuDetailsDto>>(_menuDal.GetMenusByRestaurantId(restaurantId), Messages.Successful);
        }

        public IResult Update(Menu menu)
        {
            var result=_menuDal.Update(menu);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.Unsuccessful);
        }
    }
}
