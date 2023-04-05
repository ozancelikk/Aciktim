using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_OrderDal : MongoDB_RepositoryBase<Order, MongoDB_Context<Order, MongoDB_OrderCollection>>, IOrderDal
    {
        public List<OrderDto> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            using (var orderContext = new MongoDB_Context<Order,MongoDB_OrderCollection>())
            {
                orderContext.GetMongoDBCollection();
                orders = orderContext.collection.Find<Order>(document => true).ToList();
            }
            List<Customer>customers = new List<Customer>();
            using (var customer=new MongoDB_Context<Customer,MongoDB_CustomerCollection>())
            {
                customer.GetMongoDBCollection();
                customers = customer.collection.Find<Customer>(document => true).ToList();

            }


            var orderdto = new List<OrderDto>();

            List<Restaurant> restaurants = new List<Restaurant>();
            using (var restaurant = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurant.GetMongoDBCollection();
                restaurants = restaurant.collection.Find<Restaurant>(document => true).ToList();
            }

            foreach (var item in orders)
            {
                var currentCustomer= orderdto.Where(e => e.Customer.Id == item.CustomerId).FirstOrDefault();
                var currentRestaurant = orderdto.Where(e => e.Restaurant.Id==item.RestaurantId).FirstOrDefault();
                var dto = new OrderDto
                {
                    Id = item.Id,
                    Customer = currentCustomer.Customer,
                    EstimatedTime = currentRestaurant.EstimatedTime,
                    OrderDescription = currentCustomer.OrderDescription,
                    OrderPrice = currentCustomer.OrderPrice,
                    OrderStatus = currentCustomer.OrderStatus,
                    Restaurant = currentRestaurant.Restaurant
                };
                orderdto.Add(dto);
            }

         
            return orderdto;
        }

    }
}
