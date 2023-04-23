using AutoMapper;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.Concrete.Simples;
using Entities.Dtos;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_RestaurantDal : MongoDB_RepositoryBase<Restaurant, MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>>, IRestaurantDal
    {
        private readonly IMapper _mapper;

        public MongoDB_RestaurantDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void DeleteClaims(Restaurant restaurant)
        {
            List<OperationClaim> _operationClaims = new List<OperationClaim>();

            using (var operationClaims = new MongoDB_Context<RestaurantOperationClaim, MongoDB_RestaurantOperationClaimCollection>())
            {
                operationClaims.GetMongoDBCollection();
                operationClaims.collection.DeleteMany(c => c.RestaurantId == restaurant.Id);

            }
        }

        public List<RestaurantDto> GetAllRestaurant()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            using (var restaurantContext = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurantContext.GetMongoDBCollection();
                restaurants = restaurantContext.collection.Find<Restaurant>(document => true).ToList();
                var restaurantDtos = new List<RestaurantDto>();
                foreach (var restaurant in restaurants)
                {
                    if (restaurant.Id != null)
                    {
                        restaurantDtos.Add(new RestaurantDto
                        {
                            CategoryId = restaurant.CategoryId,
                            ClosingTime = restaurant.ClosingTime,
                            OpeningTime = restaurant.OpeningTime,
                            RestaurantAddress = restaurant.RestaurantAddress,
                            RestaurantName = restaurant.RestaurantName,
                            MinCartPrice = restaurant.MinCartPrice,
                            RestaurantRate = restaurant.RestaurantRate,
                            TaxNumber = restaurant.TaxNumber,
                            PhoneNumber = restaurant.PhoneNumber
                        });
                    }
                }
                return restaurantDtos;
            }
        }

        public List<RestaurantImageDetailDto> GetAllRestaurantWithImages()
        {
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => true).ToList();
            }
            var list = new List<RestaurantImageDetailDto>();
            List<RestaurantImage> restaurantImage = new List<RestaurantImage>();
            using (var restaurantImages = new MongoDB_Context<RestaurantImage, MongoDB_RestaurantImageCollection>())
            {
                restaurantImages.GetMongoDBCollection();
                restaurantImage = restaurantImages.collection.Find<RestaurantImage>(document => true).ToList();
            }
            foreach (var item in restaurant)
            {
                var next = new RestaurantImageDetailDto
                {
                    CategoryId = item.CategoryId,
                    ClosingTime = item.ClosingTime,
                    MailAddress = item.MailAddress,
                    OpeningTime = item.OpeningTime,
                    RestaurantAddress = item.RestaurantAddress,
                    RestaurantName = item.RestaurantName,
                    MinCartPrice = item.MinCartPrice,
                    RestaurantRate = item.RestaurantRate,
                    PhoneNumber = item.PhoneNumber,
                    Id = item.Id,
                };
                var temp = restaurantImage.FirstOrDefault(x => x.RestaurantId == item.Id);
                next.ImagePath = (temp != null) ? (item.Id + "/" + temp.ImagePath) : null;
                list.Add(next);
            }
            return list;
        }

        public List<RestaurantImageDetailDto> GetRestaurantsByCategoryId(string categoryId)
        {
            var list = new List<RestaurantImageDetailDto>();
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => document.CategoryId == categoryId).ToList();
            }


            List<RestaurantImage> restaurantImage = new List<RestaurantImage>();
            using (var restaurantImages = new MongoDB_Context<RestaurantImage, MongoDB_RestaurantImageCollection>())
            {
                restaurantImages.GetMongoDBCollection();
                restaurantImage = restaurantImages.collection.Find<RestaurantImage>(document => true).ToList();
            }

            foreach (var item in restaurant)
            {
                var next = new RestaurantImageDetailDto
                {
                    CategoryId = item.CategoryId,
                    ClosingTime = item.ClosingTime,
                    MailAddress = item.MailAddress,
                    OpeningTime = item.OpeningTime,
                    RestaurantAddress = item.RestaurantAddress,
                    RestaurantName = item.RestaurantName,
                    MinCartPrice = item.MinCartPrice,
                    RestaurantRate = item.RestaurantRate,
                    PhoneNumber = item.PhoneNumber,
                    Id = item.Id,
                };
                var temp = restaurantImage.FirstOrDefault(x => x.RestaurantId == item.Id);
                next.ImagePath = (temp != null) ? (item.Id + "/" + temp.ImagePath) : null;
                list.Add(next);
            }
            return list;
        }


        public RestaurantImageDetailDto GetRestaurantDetailImagesById(string restaurantId)
        {
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => document.Id == restaurantId).ToList();
            }
            var list = new List<RestaurantImageDetailDto>();
            List<RestaurantImage> restaurantImage = new List<RestaurantImage>();
            using (var restaurantImages = new MongoDB_Context<RestaurantImage, MongoDB_RestaurantImageCollection>())
            {
                restaurantImages.GetMongoDBCollection();
                restaurantImage = restaurantImages.collection.Find<RestaurantImage>(document => document.RestaurantId == restaurantId).ToList();
            }
            //var temp = new RestaurantImageDetailDto();

            //if (restaurantImage.Any())
            //{
            //    temp = new RestaurantImageDetailDto
            //    {
            //        CategoryId = restaurant[0].CategoryId,
            //        ClosingTime = restaurant[0].ClosingTime,
            //        Id = restaurant[0].Id,
            //        ImagePath = restaurantImage[0].ImagePath,
            //        MailAddress = restaurant[0].MailAddress,
            //        MinCartPrice = restaurant[0].MinCartPrice,
            //        OpeningTime = restaurant[0].OpeningTime,
            //        RestaurantAddress = restaurant[0].RestaurantAddress,
            //        RestaurantName = restaurant[0].RestaurantName,
            //        RestaurantRate = restaurant[0].RestaurantRate,
            //        PhoneNumber = restaurant[0].PhoneNumber
            //    };
            //}
            //else
            //{

            //    temp = new RestaurantImageDetailDto
            //    {
            //        CategoryId = restaurant[0].CategoryId,
            //        ClosingTime = restaurant[0].ClosingTime,
            //        Id = restaurant[0].Id,
            //        ImagePath = null,
            //        MailAddress = restaurant[0].MailAddress,
            //        MinCartPrice = restaurant[0].MinCartPrice,
            //        OpeningTime = restaurant[0].OpeningTime,
            //        RestaurantAddress = restaurant[0].RestaurantAddress,
            //        RestaurantName = restaurant[0].RestaurantName,
            //        RestaurantRate = restaurant[0].RestaurantRate,
            //        PhoneNumber = restaurant[0].PhoneNumber
            //    };
            //}

            var temp = new RestaurantImageDetailDto() {
                CategoryId = restaurant[0].CategoryId,
                ClosingTime = restaurant[0].ClosingTime,
                Id = restaurant[0].Id,
                //ImagePath = restaurantImage[0].ImagePath,
                MailAddress = restaurant[0].MailAddress,
                MinCartPrice = restaurant[0].MinCartPrice,
                OpeningTime = restaurant[0].OpeningTime,
                RestaurantAddress = restaurant[0].RestaurantAddress,
                RestaurantName = restaurant[0].RestaurantName,
                RestaurantRate = restaurant[0].RestaurantRate,
                PhoneNumber = restaurant[0].PhoneNumber
            };
            temp.ImagePath = restaurantImage.Any() ? restaurantImage[0].ImagePath : null;
            return temp;
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

        public RestaurantDetailsDto GetRestaurantById(string id)
        {
            using (var restaurantContext = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurantContext.GetMongoDBCollection();
                var restaurants = restaurantContext.collection.Find<Restaurant>(document => true).ToList();
                var temp = restaurants.Find(r => r.Id == id);

                var real = _mapper.Map<RestaurantDetailsDto>(temp);
                return real;
            }
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
                OperationClaims = GetClaims(restaurant)
            };
            return restaurantEvolved;
        }
    }
}
