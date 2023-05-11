﻿using Core.DataAccess.Databases;
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
    }
}
