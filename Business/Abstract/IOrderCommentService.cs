using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderCommentService
    {
        IDataResult<List<OrderComment>> GetAll();
        IDataResult<OrderComment> GetById(string id);
        IResult Add(OrderComment orderCommet);
        IResult Update(OrderComment orderCommet);
        IResult Delete(string id);
    }
}
