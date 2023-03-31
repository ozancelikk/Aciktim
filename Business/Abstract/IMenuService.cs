﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMenuService
    {
        IDataResult<List<Menu>> GetAll();
        IDataResult<Menu> GetById(string id);
        IResult Add(Menu menu);
        IResult Update(Menu menu);
        IResult Delete(string id);
    }
}