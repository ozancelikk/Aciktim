using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetById(string id);
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(string id);
        IDataResult<List<Order>> GetOrderDetailsByCustomerId(string customerId); 
        IDataResult<List<Order>> GetCompletedOrdersDetailsByCustomerId(string customerId); 
        IDataResult<List<Order>> GetActiveOrdersDetailsByCustomerId(string customerId);
        IDataResult<List<Order>> GetActiveOrdersDetailsByRestaurantId(string restaurantId);
        IDataResult<List<Order>> GetPassiveOrdersDetailsByRestaurantId(string restaurantId);
        IDataResult<List<OrderDto>> GetAllOrdersDetails();
        IDataResult<OrdersByDateDto> GetTodayOrders();
        IDataResult<OrdersByDateDto> GetYesterdayOrders();
        IDataResult<List<OrdersByRestaurantDto>>  OrderMenusByRestaurantId(string restaurantId);

    }
}
