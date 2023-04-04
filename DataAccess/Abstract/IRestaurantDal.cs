using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRestaurantDal:IEntityRepository<Restaurant>
    {
        List<RestaurantEvolved> GetAllWithClaims();
        List<OperationClaim> GetClaims(Restaurant restaurant);
        RestaurantEvolved GetWithClaims(string restaurantId);
        void DeleteClaims(Restaurant restaurant);
    }
}
