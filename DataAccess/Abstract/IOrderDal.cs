using Core.DataAccess.Databases;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
        List<OrderDto> GetAllOrders();
        List<Order> GetActiveOrdersByCustomerId(string  customerId);
        OrdersByDateDto GetOrdersByDate(string date);
        OrdersByDateDto GetOrdersDateByRestaurantId(string date,string restaurantId);
        List<OrdersByRestaurantDto> GetOrdersByRestaurantId(string restaurantId);
        List<Order> GetOrdersByRestaurantAndCustomerId(string customerId,string restaurantId);
        List<Order> GetCustomerOrderDetailsByDate(string start, string end, string customerId);
        List<Order> GetRestaurantOrderDetailsByDate(string start, string end, string restaurantId); //for admin panel
        List<Order> GetRestaurantActiveOrderDetailsByDate(string start, string end, string restaurantId); // for restaurant
        List<Order> GetRestaurantPassiveOrderDetailsByDate(string start, string end, string restaurantId); // for restaurant
    }
}
