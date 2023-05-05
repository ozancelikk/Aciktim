using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMenuService
    {
        IDataResult<List<Menu>> GetAll();
        IDataResult<Menu> GetById(string id);
        IDataResult<string> AddMenuWithImage(Menu menu);
        IResult Add(Menu menu);
        IResult Update(Menu menu);
        IResult Delete(string id);
        IDataResult<List<MenuDetailsDto>> GetMenusDetailsByRestaurantId(string restaurantId);
    }
}
