using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISupportService
    {
        IDataResult<List<Support>> GetAll();
        IDataResult<Support> GetById(string id);
        IResult Add(Support support);
        IResult Update(Support support);
        IResult Delete(string id);
    }
}
