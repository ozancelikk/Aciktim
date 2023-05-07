using Core.DataAccess.Databases;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete.Simples;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRestaurantDal:IEntityRepository<Restaurant>
    {
        List<RestaurantDto> GetAllRestaurant();
        RestaurantDetailsDto GetRestaurantById(string id);
        List<RestaurantEvolved> GetAllWithClaims();
        List<OperationClaim> GetClaims(Restaurant restaurant);
        RestaurantEvolved GetWithClaims(string restaurantId);
        void DeleteClaims(Restaurant restaurant);
        List<RestaurantImageDetailDto> GetAllRestaurantWithImages();
        List<RestaurantImageDetailDto> GetActiveRestaurantsWithImages();
        List<RestaurantImageDetailDto> GetPassiveRestaurantsWithImages();
        List<RestaurantImageDetailDto> GetRestaurantsByCategoryId(params string[] categoryId);
        RestaurantImageDetailDto GetRestaurantDetailImagesById(string restaurantId);
        List<RestaurantOrderDto> GetRestaurantsOrderNumber();
    }
}
