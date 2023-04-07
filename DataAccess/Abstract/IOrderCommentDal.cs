using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderCommentDal:IEntityRepository<OrderComment>
    {
        List<OrderCommentDto> GetOrderCommentsByRestaurantId(string restaurantId);
    }
}
