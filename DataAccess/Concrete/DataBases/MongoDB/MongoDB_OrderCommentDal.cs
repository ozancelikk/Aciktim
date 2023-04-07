using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.Dtos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_OrderCommentDal : MongoDB_RepositoryBase<OrderComment, MongoDB_Context<OrderComment, MongoDB_OrderCommentCollection>>, IOrderCommentDal
    {
        public List<OrderCommentDto> GetOrderCommentsByRestaurantId(string restaurantId)
        {
            List<Order> orders = new List<Order>();
            List<Customer> customers = new List<Customer>();
            List<Restaurant> restaurants = new List<Restaurant>();
            using (var orderContext = new MongoDB_Context<Order, MongoDB_OrderCollection>())
            {
                orderContext.GetMongoDBCollection();
                orders = orderContext.collection.Find<Order>(x=>x.RestaurantId== restaurantId).ToList();
            }

            using (var customer = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customer.GetMongoDBCollection();
                customers = customer.collection.Find<Customer>(document => true).ToList();

            }
            var orderdto = new List<OrderCommentDto>();   //restaurant-customer


            using (var restaurant = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurant.GetMongoDBCollection();
                restaurants = restaurant.collection.Find<Restaurant>(document => true).ToList();
            }
            foreach (var item in orders)
            {
                var currentRestaurant = restaurants.Where(x => x.Id == item.RestaurantId).FirstOrDefault();
                var currentCustomer = customers.Where(x => x.Id == item.CustomerId).FirstOrDefault();
                orderdto.Add(new OrderCommentDto
                {
                    OrderId = item.Id,
                    Content=item.OrderDescription,
                    CustomerMail=currentCustomer.MailAddress,
                    RestaurantName=currentRestaurant.RestaurantName,
                    OrderCommentDate=DateTime.Now.ToShortDateString(),
                    OrderStar=2
                });
            }
            return orderdto;
        }
    }
}
