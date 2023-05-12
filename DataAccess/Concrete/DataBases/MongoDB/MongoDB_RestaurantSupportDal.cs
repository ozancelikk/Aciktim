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
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_RestaurantSupportDal : MongoDB_RepositoryBase<RestaurantSupport, MongoDB_Context<RestaurantSupport, MongoDB_RestaurantSupportCollection>>, IRestaurantSupportDal
    {
        public List<RestaurantSupportListDto> GetMailDetails()
        {
            List<RestaurantSupportListDto> list = new List<RestaurantSupportListDto>();
            List<RestaurantSupport> supports = new List<RestaurantSupport>();
            using var supportContext = new MongoDB_Context<RestaurantSupport, MongoDB_RestaurantSupportCollection>();
            supportContext.GetMongoDBCollection();
            supports = supportContext.collection.Find<RestaurantSupport>(document => true).ToList();


            List<Restaurant> restaurants = new List<Restaurant>();
            using var restaurantContext = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>();
            restaurantContext.GetMongoDBCollection();
            restaurants = restaurantContext.collection.Find<Restaurant>(document => true).ToList();

            foreach (var item in supports)
            {
                var restaurant = restaurants.Where(x => x.Id == item.RestaurantId).FirstOrDefault();
                if (restaurant != null)
                {
                    list.Add(new RestaurantSupportListDto
                    {
                        RestaurantId = item.RestaurantId,
                        Content = item.Content,
                        RestaurantName = restaurant.RestaurantName,
                        Id = item.Id,
                        Mail = item.Mail,
                        Subject = item.Subject,
                    });
                }

            }
            return list;
        }

        public RestaurantSupportListDto GetMailDetailsByRestaurantId(string restaurantId)
        {
            RestaurantSupportListDto list = new RestaurantSupportListDto();
            List<RestaurantSupport> supports = new List<RestaurantSupport>();
            using var supportContext = new MongoDB_Context<RestaurantSupport, MongoDB_RestaurantSupportCollection>();
            supportContext.GetMongoDBCollection();
            supports = supportContext.collection.Find<RestaurantSupport>(document => true).ToList();


            List<Restaurant> restaurants = new List<Restaurant>();
            using var restaurantContext = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>();
            restaurantContext.GetMongoDBCollection();
            restaurants = restaurantContext.collection.Find<Restaurant>(document => document.Id==restaurantId).ToList();

            foreach (var item in supports)
            {
                var restaurant = restaurants.Where(x => x.Id == item.RestaurantId).FirstOrDefault();
                if (restaurant != null)
                {
                    list.Subject = item.Subject;
                    list.RestaurantId = item.RestaurantId;
                    list.RestaurantName = restaurant.RestaurantName;
                    list.Id = item.Id;
                    list.Content = item.Content;
                    list.Mail = item.Mail;
                
                    
                }

            }
            return list;
        }
    }
}
