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
                            PhoneNumber = restaurant.PhoneNumber,
                            Status = false
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


            List<RestaurantComment> restaurantComment = new List<RestaurantComment>();
            using (var restaurantComments = new MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>())
            {
                restaurantComments.GetMongoDBCollection();
                restaurantComment = restaurantComments.collection.Find<RestaurantComment>(document => true).ToList(); //tüm restoranlar
            }

            foreach (var item in restaurant)
            {
                double total = 0;
                var currentComment = restaurantComment.Where(x => x.RestaurantId == item.Id).ToList();  // o anki restorana ait yorumların listesi

                foreach (var item2 in currentComment)
                {
                    total += item2.RestaurantRate;
                }
                var totalComment = currentComment.Count;
                var next = new RestaurantImageDetailDto
                {
                    CategoryId = item.CategoryId,
                    ClosingTime = item.ClosingTime,
                    MailAddress = item.MailAddress,
                    OpeningTime = item.OpeningTime,
                    RestaurantAddress = item.RestaurantAddress,
                    RestaurantName = item.RestaurantName,
                    MinCartPrice = item.MinCartPrice,
                    TaxNumber = item.TaxNumber,
                    RestaurantRate = totalComment == 0 ? 0 : total / totalComment,
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

            List<RestaurantComment> restaurantComment = new List<RestaurantComment>();
            using (var restaurantComments = new MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>())
            {
                restaurantComments.GetMongoDBCollection();
                restaurantComment = restaurantComments.collection.Find<RestaurantComment>(document => true).ToList(); //tüm restoranlar
            }


            double total = 0;
            var currentComment = restaurantComment.Where(x => x.RestaurantId == restaurant[0].Id).ToList();  // o anki restorana ait yorumların listesi

            foreach (var item2 in currentComment)
            {
                total += item2.RestaurantRate;
            }
            var totalComment = currentComment.Count;


            var temp = new RestaurantImageDetailDto()
            {
                CategoryId = restaurant[0].CategoryId,
                ClosingTime = restaurant[0].ClosingTime,
                Id = restaurant[0].Id,
                MailAddress = restaurant[0].MailAddress,
                MinCartPrice = restaurant[0].MinCartPrice,
                OpeningTime = restaurant[0].OpeningTime,
                RestaurantAddress = restaurant[0].RestaurantAddress,
                RestaurantName = restaurant[0].RestaurantName,
                RestaurantRate = totalComment == 0 ? 0 : total / totalComment,
                PhoneNumber = restaurant[0].PhoneNumber,
                TaxNumber = restaurant[0].TaxNumber,
                RegisterDate = restaurant[0].RegisterDate,


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

        public List<RestaurantImageDetailDto> GetRestaurantsByCategoryId(params string[] categoryId)
        {
            var list = new List<RestaurantImageDetailDto>();
            List<Restaurant> restaurant = new List<Restaurant>();
            List<Restaurant> myRestaurants = new List<Restaurant>();
            string[] roles = new string[0];
            foreach (var item in categoryId)
            {
                if (item == null)
                {
                    return null;
                }
                roles = item.Split(',');
            }

            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => true).ToList();

                foreach (var item in restaurant)
                {
                    if (roles.Contains(item.CategoryId))
                    {
                        myRestaurants.Add(item);
                    }
                }
            }
            List<RestaurantImage> restaurantImage = new List<RestaurantImage>();
            using (var restaurantImages = new MongoDB_Context<RestaurantImage, MongoDB_RestaurantImageCollection>())
            {
                restaurantImages.GetMongoDBCollection();
                restaurantImage = restaurantImages.collection.Find<RestaurantImage>(document => true).ToList();
            }


            List<RestaurantComment> restaurantComment = new List<RestaurantComment>();
            using (var restaurantComments = new MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>())
            {
                restaurantComments.GetMongoDBCollection();
                restaurantComment = restaurantComments.collection.Find<RestaurantComment>(document => true).ToList(); //tüm restoranlar
            }
            double total = 0;
            foreach (var item in myRestaurants)
            {
                var currentComment = restaurantComment.Where(x => x.RestaurantId == item.Id).ToList();  // o anki restorana ait yorumların listesi

                foreach (var item2 in currentComment)
                {
                    total += item2.RestaurantRate;
                }
                var totalComment = currentComment.Count;
                var next = new RestaurantImageDetailDto
                {
                    CategoryId = item.CategoryId,
                    ClosingTime = item.ClosingTime,
                    MailAddress = item.MailAddress,
                    OpeningTime = item.OpeningTime,
                    RestaurantAddress = item.RestaurantAddress,
                    RestaurantName = item.RestaurantName,
                    MinCartPrice = item.MinCartPrice,
                    RestaurantRate = totalComment == 0 ? 0 : total / totalComment,
                    PhoneNumber = item.PhoneNumber,
                    Id = item.Id,
                    RegisterDate = item.RegisterDate,

                };
                var temp = restaurantImage.FirstOrDefault(x => x.RestaurantId == item.Id);
                next.ImagePath = (temp != null) ? (item.Id + "/" + temp.ImagePath) : null;
                list.Add(next);
                total = 0;
            }
            return list;
        }

        public List<RestaurantImageDetailDto> GetActiveRestaurantsWithImages()
        {
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => document.Status == true).ToList();
            }
            var list = new List<RestaurantImageDetailDto>();
            List<RestaurantImage> restaurantImage = new List<RestaurantImage>();
            using (var restaurantImages = new MongoDB_Context<RestaurantImage, MongoDB_RestaurantImageCollection>())
            {
                restaurantImages.GetMongoDBCollection();
                restaurantImage = restaurantImages.collection.Find<RestaurantImage>(document => true).ToList();
            }


            List<RestaurantComment> restaurantComment = new List<RestaurantComment>();
            using (var restaurantComments = new MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>())
            {
                restaurantComments.GetMongoDBCollection();
                restaurantComment = restaurantComments.collection.Find<RestaurantComment>(document => true).ToList(); //tüm restoranlar
            }

            foreach (var item in restaurant)
            {
                double total = 0;
                var currentComment = restaurantComment.Where(x => x.RestaurantId == item.Id).ToList();  // o anki restorana ait yorumların listesi

                foreach (var item2 in currentComment)
                {
                    total += item2.RestaurantRate;
                }
                var totalComment = currentComment.Count;
                var next = new RestaurantImageDetailDto
                {
                    CategoryId = item.CategoryId,
                    ClosingTime = item.ClosingTime,
                    MailAddress = item.MailAddress,
                    OpeningTime = item.OpeningTime,
                    RestaurantAddress = item.RestaurantAddress,
                    RestaurantName = item.RestaurantName,
                    MinCartPrice = item.MinCartPrice,
                    TaxNumber = item.TaxNumber,
                    RestaurantRate = totalComment == 0 ? 0 : total / totalComment,
                    PhoneNumber = item.PhoneNumber,
                    Id = item.Id,
                    RegisterDate = item.RegisterDate,
                };
                var temp = restaurantImage.FirstOrDefault(x => x.RestaurantId == item.Id);
                next.ImagePath = (temp != null) ? (item.Id + "/" + temp.ImagePath) : null;
                list.Add(next);
            }
            return list;
        }


        public List<RestaurantImageDetailDto> GetPassiveRestaurantsWithImages()
        {
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => document.Status == false).ToList();
            }
            var list = new List<RestaurantImageDetailDto>();
            List<RestaurantImage> restaurantImage = new List<RestaurantImage>();
            using (var restaurantImages = new MongoDB_Context<RestaurantImage, MongoDB_RestaurantImageCollection>())
            {
                restaurantImages.GetMongoDBCollection();
                restaurantImage = restaurantImages.collection.Find<RestaurantImage>(document => true).ToList();
            }


            List<RestaurantComment> restaurantComment = new List<RestaurantComment>();
            using (var restaurantComments = new MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>())
            {
                restaurantComments.GetMongoDBCollection();
                restaurantComment = restaurantComments.collection.Find<RestaurantComment>(document => true).ToList(); //tüm restoranlar
            }

            foreach (var item in restaurant)
            {
                double total = 0;
                var currentComment = restaurantComment.Where(x => x.RestaurantId == item.Id).ToList();  // o anki restorana ait yorumların listesi

                foreach (var item2 in currentComment)
                {
                    total += item2.RestaurantRate;
                }
                var totalComment = currentComment.Count;
                var next = new RestaurantImageDetailDto
                {
                    CategoryId = item.CategoryId,
                    ClosingTime = item.ClosingTime,
                    MailAddress = item.MailAddress,
                    OpeningTime = item.OpeningTime,
                    RestaurantAddress = item.RestaurantAddress,
                    RestaurantName = item.RestaurantName,
                    MinCartPrice = item.MinCartPrice,
                    TaxNumber = item.TaxNumber,
                    RestaurantRate = totalComment == 0 ? 0 : total / totalComment,
                    PhoneNumber = item.PhoneNumber,
                    Id = item.Id,
                    RegisterDate = item.RegisterDate,
                };
                var temp = restaurantImage.FirstOrDefault(x => x.RestaurantId == item.Id);
                next.ImagePath = (temp != null) ? (item.Id + "/" + temp.ImagePath) : null;
                list.Add(next);
            }
            return list;
        }

        public List<RestaurantOrderDto> GetRestaurantsOrderNumber()
        {
            List<RestaurantOrderDto> myList = new List<RestaurantOrderDto>();

            List<Restaurant> restaurant = new List<Restaurant>();

            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => true).ToList();
            }
            List<Order> order = new List<Order>();
            using (var orders = new MongoDB_Context<Order, MongoDB_OrderCollection>())
            {
                orders.GetMongoDBCollection();
                order = orders.collection.Find<Order>(document => document.OrderStatus == "Tamamlandı" ).ToList();
            }

            foreach (var item in restaurant)
            {
                var currentRestaurantOrderNumber = order.Where(x => x.RestaurantId == item.Id).ToList().Count;
                myList.Add(new RestaurantOrderDto
                {
                    RestaurantName = item.RestaurantName,
                    RestaurantOrderNumber = currentRestaurantOrderNumber
                });

            }
            return myList;
        }
    }
}
