using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.Databases.MongoDB
{
    public class MongoDB_OrderDal : MongoDB_RepositoryBase<Order, MongoDB_Context<Order, MongoDB_OrderCollection>>, IOrderDal
    {
        public List<Order> GetActiveOrdersByCustomerId(string customerId)
        {

            List<Order> orders = new List<Order>();
            List<Customer> customers = new List<Customer>();
            List<Menu> menus = new List<Menu>();
            List<MenuImage> menuImages = new List<MenuImage>();
            List<Restaurant> restaurants = new List<Restaurant>();
            List<CustomerAddresses> addresses = new List<CustomerAddresses>();

            using (var addressContext = new MongoDB_Context<CustomerAddresses, MongoDB_CustomerAddressesCollection>())
            {
                addressContext.GetMongoDBCollection();
                addresses = addressContext.collection.Find<CustomerAddresses>(document => true).ToList();
            }

            using (var menusContext = new MongoDB_Context<Menu, MongoDB_MenuCollection>())
            {
                menusContext.GetMongoDBCollection();
                menus = menusContext.collection.Find<Menu>(document => true).ToList();
            }

            using (var menuImagesContext = new MongoDB_Context<MenuImage, MongoDB_MenuImageCollection>())
            {
                menuImagesContext.GetMongoDBCollection();
                menuImages = menuImagesContext.collection.Find<MenuImage>(document => true).ToList();
            }


            using (var orderContext = new MongoDB_Context<Order, MongoDB_OrderCollection>())
            {
                orderContext.GetMongoDBCollection();
                orders = orderContext.collection.Find<Order>(document => document.OrderStatus == "Hazırlanıyor" || document.OrderStatus == "Alındı" || document.OrderStatus == "Kuryede").ToList();
            }

            using (var customer = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customer.GetMongoDBCollection();
                customers = customer.collection.Find<Customer>(document => document.Id == customerId).ToList();

            }
            var orderdto = new List<OrderDto>();   //restaurant-customer


            using (var restaurant = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurant.GetMongoDBCollection();
                restaurants = restaurant.collection.Find<Restaurant>(document => true).ToList();
            }
            var list = new List<Order>();



            foreach (var item in orders)
            {
                var currentCustomer = customers.Where(e => e.Id == item.CustomerId).FirstOrDefault();
                var currentRestaurant = restaurants.Where(e => e.Id == item.RestaurantId).FirstOrDefault();
                var currentAddress = addresses.Where(c => c.CustomerId == item.CustomerId).FirstOrDefault();
                var currentMenu = menus.Where(x => x.RestaurantId == item.RestaurantId).FirstOrDefault();
                var currentMenuImage = menuImages.Where(x => x.MenuId == currentMenu.Id).FirstOrDefault();
                if (currentCustomer != null)
                {
                    list.Add(new Order
                    {
                        CustomerId = currentCustomer.Id,
                        Address = currentAddress.Address,
                        Id = item.Id,
                        OrderStatus = item.OrderStatus,
                        OrderDate = item.OrderDate,
                        EstimatedTime = item.EstimatedTime,
                        FirstName = currentCustomer.FirstName,
                        LastName = currentCustomer.LastName,
                        Menus = item.Menus,
                        OrderDescription = item.OrderDescription,
                        RestaurantId = currentRestaurant.Id,
                        RestaurantName = currentRestaurant.RestaurantName
                    }
                );
                }

            }
            return list;

        }

        public List<OrderDto> GetAllOrders()
        {

            List<Order> orders = new List<Order>();
            List<Customer> customers = new List<Customer>();
            List<Menu> menus = new List<Menu>();
            List<MenuImage> menuImages = new List<MenuImage>();
            List<Restaurant> restaurants = new List<Restaurant>();
            List<CustomerAddresses> addresses = new List<CustomerAddresses>();

            using (var addressContext = new MongoDB_Context<CustomerAddresses, MongoDB_CustomerAddressesCollection>())
            {
                addressContext.GetMongoDBCollection();
                addresses = addressContext.collection.Find<CustomerAddresses>(document => true).ToList();
            }

            using (var menusContext = new MongoDB_Context<Menu, MongoDB_MenuCollection>())
            {
                menusContext.GetMongoDBCollection();
                menus = menusContext.collection.Find<Menu>(document => true).ToList();
            }

            using (var menuImagesContext = new MongoDB_Context<MenuImage, MongoDB_MenuImageCollection>())
            {
                menuImagesContext.GetMongoDBCollection();
                menuImages = menuImagesContext.collection.Find<MenuImage>(document => true).ToList();
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
            var list = new List<OrderMenuDetail>();



            foreach (var item in orders)
            {
                var currentCustomer = customers.Where(e => e.Id == item.CustomerId).FirstOrDefault();
                var currentRestaurant = restaurants.Where(e => e.Id == item.RestaurantId).FirstOrDefault();
                var currentAddress = addresses.Where(c => c.CustomerId == item.CustomerId).FirstOrDefault();
                var currentMenu = menus.Where(x => x.RestaurantId == item.RestaurantId).FirstOrDefault();
                var currentMenuImage = menuImages.Where(x => x.MenuId == currentMenu.Id).FirstOrDefault();

                list.Add(new OrderMenuDetail
                {

                    MenuName = currentMenu.MenuTitle,
                    OrderPrice = currentMenu.MenuPrice,
                    RestaurantId = currentRestaurant.Id,
                    Quantity = 1,
                    MenuImage = currentMenuImage.ImagePath,
                });

                var dto = new OrderDto
                {
                    FirstName = currentCustomer.FirstName,
                    OrderDescription = item.OrderDescription,
                    EstimatedTime = item.EstimatedTime,
                    OrderStatus = item.OrderStatus,
                    LastName = currentCustomer.LastName,
                    Address = currentAddress.Address,
                    PhoneNumber = currentCustomer.PhoneNumber,
                    CustomerId = currentCustomer.Id,
                    Menus = list
                };
                orderdto.Add(dto);
            }
            return orderdto;

        }

        public OrdersByDateDto GetOrdersByDate(string date)
        {
            List<Order> orders = new List<Order>();
            using (var orderContext = new MongoDB_Context<Order, MongoDB_OrderCollection>())
            {
                orderContext.GetMongoDBCollection();
                orders = orderContext.collection.Find<Order>(document => true).ToList();
            }
            var count = 0;
            foreach (var order in orders)
            {
                var a = order.OrderDate.Split('.', ' ');
                var orderDate = a[0] + "." + a[1] + "." + a[2]; // o anki siparişin tarihi var
                if (orderDate == date) // istediğimiz sipiarş
                {
                    count++;
                }
            }
            var x = new OrdersByDateDto { Count = count, Date = date };
            return x;
        }

        public List<OrdersByRestaurantDto> GetOrdersByRestaurantId(string restaurantId)
        {
            List<OrdersByRestaurantDto> orderDtos = new List<OrdersByRestaurantDto>();
            List<Order> orders = new List<Order>();
            using (var orderContext = new MongoDB_Context<Order, MongoDB_OrderCollection>())
            {
                orderContext.GetMongoDBCollection();
                orders = orderContext.collection.Find<Order>(document => document.RestaurantId == restaurantId).ToList();
            }
            List<Restaurant>restaurants= new List<Restaurant>();
            using (var restaurant = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurant.GetMongoDBCollection();
                restaurants = restaurant.collection.Find<Restaurant>(document => true).ToList();
            }
            Dictionary<string, int> menuCount = new Dictionary<string, int>();
            foreach (var item in orders)
            {
                foreach (var menu in item.Menus)
                {
                    string menuName = (string)menu.MenuName;
                    if (!menuCount.ContainsKey(menuName))
                    {
                        menuCount[menuName] = 0;
                    }
                    menuCount[menuName] += (int)menu.Quantity;
                }
            }

            var topOrderedMenus = menuCount.OrderByDescending(x => x.Value).Take(5);
            Dictionary<string, int> topOrderedMenuDict = topOrderedMenus.ToDictionary(x => x.Key, x => x.Value);

            // En fazla sipariş verilen 5 menüyü yazdır
            if (topOrderedMenuDict.Any())
            {
                Console.WriteLine("En fazla sipariş verilen 5 menü:");
                foreach (var menu in topOrderedMenuDict)
                {
                    orderDtos.Add(new OrdersByRestaurantDto{
                        MenuName=menu.Key,
                        Quantity=menu.Value
                    });
                    Console.WriteLine($"{menu.Key} ({menu.Value} sipariş)");
                }
            }
            else
            {
                Console.WriteLine("Hiçbir menü sipariş edilmedi.");
            }
            return orderDtos;
        }
    }
}
