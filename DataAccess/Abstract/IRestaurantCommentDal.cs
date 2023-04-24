using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRestaurantCommentDal : IEntityRepository<RestaurantComment>
    {
        List<RestaurantCommentDetailsDto> GetCommentByRestaurantId(string restaurantId);
    }
}
