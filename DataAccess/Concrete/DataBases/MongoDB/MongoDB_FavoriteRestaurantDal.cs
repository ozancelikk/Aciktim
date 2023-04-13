using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_FavoriteRestaurantDal : MongoDB_RepositoryBase<FavoriteRestaurant, MongoDB_Context<FavoriteRestaurant, MongoDB_FavoriteRestaurantCollection>>, IFavoriteRestaurantDal
    {
        public List<FavoriteRestaurantDto> GetAllFavoriteRestaurant(string id)
        {
            List<Customer> customers = new List<Customer>();
            using (var customerContext = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customerContext.GetMongoDBCollection();
                customers = customerContext.collection.Find<Customer>(document => true).ToList();
            }
            List<FavoriteRestaurant> restaurants = new List<FavoriteRestaurant>();
            using (var restaurantContext = new MongoDB_Context<FavoriteRestaurant, MongoDB_FavoriteRestaurantCollection>())
            {
                restaurantContext.GetMongoDBCollection();
                restaurants = restaurantContext.collection.Find<FavoriteRestaurant>(document => true).ToList();
            }
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurantContext = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurantContext.GetMongoDBCollection();
                restaurant = restaurantContext.collection.Find<Restaurant>(document => true).ToList();
            }

            var temp = new List<FavoriteRestaurantDto>();
            foreach (var item in restaurants)
            {
                var favorite = restaurants.Find(x => x.CustomerId == id);
                var currentRestaurant=restaurant.Find(x=>x.Id == item.RestaurantId);
                temp.Add(new FavoriteRestaurantDto
                {
                   ClosingTime=currentRestaurant.ClosingTime,
                   RestaurantId=item.RestaurantId,
                   CustomerId=item.CustomerId,
                   OpeningTime=currentRestaurant.OpeningTime,
                   RestaurantAddress = currentRestaurant.RestaurantAddress,
                   RestaurantName = currentRestaurant.RestaurantName,
                   Status = true      
                });
            }
            return temp;
        }
    }
}
