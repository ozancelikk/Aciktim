using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<OrderDto>> GetAll();
        IDataResult<Order> GetById(string id);
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(string id);
    }
}
