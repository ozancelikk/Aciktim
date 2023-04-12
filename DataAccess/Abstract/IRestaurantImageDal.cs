using Core.DataAccess.Databases;
using Core.DataAccess.Databases.MongoDB;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRestaurantImageDal : IEntityRepository<RestaurantImage>
    {
    }
}
