using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.Dtos;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_OrderDal : MongoDB_RepositoryBase<Order, MongoDB_Context<Order, MongoDB_OrderCollection>>, IOrderDal
    {
        public List<OrderDto> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            List<Customer> customers = new List<Customer>();
            List<Restaurant> restaurants = new List<Restaurant>();
            List<CustomerAddresses> addresses = new List<CustomerAddresses>();

            using (var addressContext = new MongoDB_Context<CustomerAddresses, MongoDB_CustomerAddressesCollection>())
            {
                addressContext.GetMongoDBCollection();
                addresses = addressContext.collection.Find<CustomerAddresses>(document => true).ToList();
            }

            using (var orderContext = new MongoDB_Context<Order, MongoDB_OrderCollection>())
            {
                orderContext.GetMongoDBCollection();
                orders = orderContext.collection.Find<Order>(document => true).ToList();
            }

            using (var customer = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customer.GetMongoDBCollection();
                customers = customer.collection.Find<Customer>(document => true).ToList();

            }
            var orderdto = new List<OrderDto>();   //restaurant-customer


            using (var restaurant = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurant.GetMongoDBCollection();
                restaurants = restaurant.collection.Find<Restaurant>(document => true).ToList();
            }

            foreach (var item in orders)
            {
                var currentCustomer = customers.Where(e => e.Id == item.CustomerId).FirstOrDefault();
                var currentRestaurant = restaurants.Where(e => e.Id == item.RestaurantId).FirstOrDefault();
                var currentAddress = addresses.Where(c => c.CustomerId == item.CustomerId).FirstOrDefault();

                var dto = new OrderDto
                {
                    FirstName = currentCustomer.FirstName,
                    RestaurantName = currentRestaurant.RestaurantName,
                    OrderDescription = item.OrderDescription,
                    EstimatedTime = item.EstimatedTime,
                    OrderPrice = item.OrderPrice,
                    OrderStatus = item.OrderStatus,
                    LastName = currentCustomer.LastName,
                    Address = currentAddress.Address,
                    PhoneNumber = currentCustomer.PhoneNumber
                };
                orderdto.Add(dto);
            }
            return orderdto;

        }
    }
}
