using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRestaurantSupportDal : IEntityRepository<RestaurantSupport>
    {
        List<RestaurantSupportListDto> GetMailDetails();
       RestaurantSupportListDto GetMailDetailsByRestaurantId(string restaurantId);
    }
}
