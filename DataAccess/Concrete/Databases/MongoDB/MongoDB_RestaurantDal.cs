using Castle.Core.Resource;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_RestaurantDal : MongoDB_RepositoryBase<Restaurant, MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>>, IRestaurantDal
    {
        public void DeleteClaims(Restaurant restaurant)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<RestaurantOperationClaim, MongoDB_RestaurantOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                operationClaims.collection.DeleteMany(c => c.RestaurantId == restaurant.Id);

            }
        }

        public List<RestaurantEvolved> GetAllWithClaims()
        {
            List<RestaurantEvolved> _restaurantEvolveds = new List<RestaurantEvolved>();
            List<Restaurant> _restaurants = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                _restaurants = restaurants.collection.Find<Restaurant>(document => true).ToList();
            }

            foreach (var restaurant in _restaurants)
            {

                RestaurantEvolved restaurantEvolved = new RestaurantEvolved
                {
                    Id = restaurant.Id,
                    Email = restaurant.MailAddress,
                    RestaurantName = restaurant.RestaurantName,
                    OperationClaims = GetClaims(restaurant)

                };
                _restaurantEvolveds.Add(restaurantEvolved);
            }

            return _restaurantEvolveds;
        }

        public List<OperationClaim> GetClaims(Restaurant restaurant)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<RestaurantOperationClaim> _restaurantOperationClaim = new List<RestaurantOperationClaim>();
            List<OperationClaim> _currentRestaurantOperationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();

                _operationClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();

            }

            using (var operationClaims = new MongoDB_Context<RestaurantOperationClaim, MongoDB_RestaurantOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _restaurantOperationClaim = operationClaims.collection.Find<RestaurantOperationClaim>(document => true).ToList();

            }


            var restaurantOperationClaims = _restaurantOperationClaim.Where(u => u.RestaurantId == restaurant.Id).ToList();
            foreach (var restaurantOperationClaim in restaurantOperationClaims)
            {
                _currentRestaurantOperationClaims.Add(_operationClaims.Where(oc => oc.Id == restaurantOperationClaim.OperationClaimId).FirstOrDefault());
            }

            return _currentRestaurantOperationClaims;
        }

        public RestaurantEvolved GetWithClaims(string restaurantId)
        {
            Restaurant restaurant = new Restaurant();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => document.Id == restaurantId).FirstOrDefault();
            }

            RestaurantEvolved restaurantEvolved = new RestaurantEvolved
            {
                Id = restaurant.Id,
                Email = restaurant.MailAddress,
                RestaurantName = restaurant.RestaurantName,
                OperationClaims = GetClaims(restaurant),
            };
            return restaurantEvolved;
        }
    }
}
