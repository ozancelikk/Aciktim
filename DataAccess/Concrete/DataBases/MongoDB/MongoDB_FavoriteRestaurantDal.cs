using AutoMapper;
using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_FavoriteRestaurantDal : MongoDB_RepositoryBase<FavoriteRestaurant, MongoDB_Context<FavoriteRestaurant, MongoDB_FavoriteRestaurantCollection>>, IFavoriteRestaurantDal
    {
        private readonly IMapper _mapper;

        public MongoDB_FavoriteRestaurantDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<FavoriteRestaurantDto> GetAllFavoriteRestaurantByCustomerId(string id)
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


            List<RestaurantImage> restaurantImages = new List<RestaurantImage>();
            using (var restaurantImageContext = new MongoDB_Context<RestaurantImage, MongoDB_RestaurantImageCollection>())
            {
                restaurantImageContext.GetMongoDBCollection();
                restaurantImages = restaurantImageContext.collection.Find<RestaurantImage>(document => true).ToList();
            }

            var list = new List<FavoriteRestaurantDto>();
            var favoriteRestaurants = restaurants.Where(x => x.CustomerId == id).ToList(); // ilgili kullanıcının favori restaurnt

            //ESKİ HALİ
            //foreach (var item in favoriteRestaurants)
            //{

            //    var currentRestaurant = restaurant.Find(x => x.Id == item.RestaurantId);
            //    var image = restaurantImages.Find(x => x.RestaurantId == item.RestaurantId);
            //    temp.Add(new FavoriteRestaurantDto
            //    {
            //        ClosingTime = currentRestaurant.ClosingTime,
            //        RestaurantId = item.RestaurantId,
            //        OpeningTime = currentRestaurant.OpeningTime,
            //        RestaurantAddress = currentRestaurant.RestaurantAddress,
            //        RestaurantName = currentRestaurant.RestaurantName,
            //        CategoryId = currentRestaurant.CategoryId,
            //        CustomerId = item.CustomerId,
            //        MailAddress = currentRestaurant.MailAddress,
            //        MinCartPrice = currentRestaurant.MinCartPrice,
            //        PhoneNumber = currentRestaurant.PhoneNumber,
            //        imagePath = image.ImagePath,
            //        RestaurantRate = currentRestaurant.RestaurantRate,
            //        Id = item.Id,
            //    });

            //}


            //------------------------------------------------------------------------------


            foreach (var item in favoriteRestaurants)
            {
                var currentRestaurant = restaurant.Find(x => x.Id == item.RestaurantId);
                //var image = restaurantImages.Find(x => x.RestaurantId == item.RestaurantId);
                var next = new FavoriteRestaurantDto
                {
                    ClosingTime = currentRestaurant.ClosingTime,
                    RestaurantId = item.RestaurantId,
                    OpeningTime = currentRestaurant.OpeningTime,
                    RestaurantAddress = currentRestaurant.RestaurantAddress,
                    RestaurantName = currentRestaurant.RestaurantName,
                    CategoryId = currentRestaurant.CategoryId,
                    CustomerId = item.CustomerId,
                    MailAddress = currentRestaurant.MailAddress,
                    MinCartPrice = currentRestaurant.MinCartPrice,
                    PhoneNumber = currentRestaurant.PhoneNumber,
                    //imagePath = image.ImagePath,
                    RestaurantRate = currentRestaurant.RestaurantRate,
                    Id = item.Id,
                };

                var image = restaurantImages.FirstOrDefault(x => x.RestaurantId == item.RestaurantId);
                next.imagePath = (image != null) ? (item.Id + "/" + image.ImagePath) : null;
                list.Add(next);
            }
            return list;
        }
    }
}
