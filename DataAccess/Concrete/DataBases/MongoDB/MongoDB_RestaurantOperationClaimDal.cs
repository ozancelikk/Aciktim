using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete.Simples;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_RestaurantOperationClaimDal : MongoDB_RepositoryBase<RestaurantOperationClaim, MongoDB_Context<RestaurantOperationClaim, MongoDB_RestaurantOperationClaimCollection>>, IRestaurantOperationClaimDal
    {
        public List<RestaurantOperationClaimsEvolved> GetAllClaims()
        {
            List<RestaurantOperationClaim> _restaurantOperationClaims = new List<RestaurantOperationClaim>();
            List<OperationClaim> _operationClaims = new List<OperationClaim>();
            List<Restaurant> _restaurants = new List<Restaurant>();
            List<RestaurantOperationClaimsEvolved> _restaurantOperationClaimsEvolved = new List<RestaurantOperationClaimsEvolved>();
            List<Customer> customers = new List<Customer>();
            using (var customerContext = new MongoDB_Context<Customer,MongoDB_CustomerCollection>())
            {
                customerContext.GetMongoDBCollection();
                customers = customerContext.collection.Find<Customer>(document=>true).ToList();
            }

            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                _operationClaims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();
            }

            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                _restaurants = restaurants.collection.Find<Restaurant>(document => true).ToList();
            }

            using (var operationClaims = new MongoDB_Context<RestaurantOperationClaim, MongoDB_RestaurantOperationClaimCollection>())
            {
                _restaurantOperationClaims = operationClaims.collection.Find<RestaurantOperationClaim>(document => true).ToList();
            }

            foreach (var restaurantOperationClaim in _restaurantOperationClaims)
            {
                var currentOperationlaim = _operationClaims.Where(o => o.Id == restaurantOperationClaim.OperationClaimId).FirstOrDefault();
                var currentUser = _restaurants.Where(u => u.Id == restaurantOperationClaim.RestaurantId).FirstOrDefault();

                if (currentUser != null && currentOperationlaim != null)
                {
                    RestaurantOperationClaimsEvolved restaurantOperationClaimsEvolved = new RestaurantOperationClaimsEvolved { Id = restaurantOperationClaim.Id, OperationClaim = currentOperationlaim.Name, OperationClaimId = currentOperationlaim.Id};
                    _restaurantOperationClaimsEvolved.Add(restaurantOperationClaimsEvolved);
                }

            }
            return _restaurantOperationClaimsEvolved;
        }

        public List<RestaurantClaimDetailsDto> GetClaimDetails()
        {
            List<Restaurant> restaurant = new List<Restaurant>();
            List<RestaurantOperationClaim> _restaurantOperationClaim = new List<RestaurantOperationClaim>();
            List<RestaurantClaimDetailsDto> dtos = new List<RestaurantClaimDetailsDto>();

            using (var customers = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                customers.GetMongoDBCollection();
                restaurant = customers.collection.Find<Restaurant>(document => true).ToList();
            }
            List<OperationClaim> claims = new List<OperationClaim>();
            using (var operationClaims = new MongoDB_Context<OperationClaim, MongoDB_OperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                claims = operationClaims.collection.Find<OperationClaim>(document => true).ToList();
            }

            List<OperationClaim> _currentUserOperationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<RestaurantOperationClaim, MongoDB_RestaurantOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                _restaurantOperationClaim = operationClaims.collection.Find<RestaurantOperationClaim>(document => true).ToList();
            }
            var restaurantOperationClaims = _restaurantOperationClaim.Where(u => true).ToList();   // restaurantların claimlerini tutuyor


            foreach (var restaurantOperationClaim in restaurantOperationClaims)
            {
                var currentRestaurant = restaurant.Find(x => x.Id == restaurantOperationClaim.RestaurantId);       // current restaurant
                var claimName = claims.Find(x => x.Id == restaurantOperationClaim.OperationClaimId);

                //var result = _mapper.Map<CustomerClaimsDetailsDto>(temp);

                dtos.Add(new RestaurantClaimDetailsDto
                {
                    OperationClaimName = claimName.Name,
                    RestaurantName = currentRestaurant.RestaurantName
                });
            }
            return dtos;
        }
    }
}
