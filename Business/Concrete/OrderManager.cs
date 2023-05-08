using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal ;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal=orderDal;
        }
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.AddingSuccessful);
        }

        public IResult Delete(string id)
        {
            var order =GetById(id);
            if (order.Data==null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _orderDal.Delete(order.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }
        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.Successful);
        }

        public IDataResult<List<OrderDto>> GetAllOrdersDetails()
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.GetAllOrders(),Messages.Successful);
        }

        public IDataResult<Order> GetById(string id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.Id == id), Messages.Successful);
        }

        public IDataResult<List<Order>> GetCompletedOrdersDetailsByCustomerId(string customerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(x => x.OrderStatus == "Tamamlandı" && x.CustomerId==customerId), Messages.Successful);
        }

        public IDataResult<List<Order>> GetActiveOrdersDetailsByCustomerId(string customerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetActiveOrdersByCustomerId(customerId), Messages.Successful);  
        }

        public IDataResult<List<Order>> GetOrderDetailsByCustomerId(string customerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(x=>x.CustomerId == customerId), Messages.Successful);
        }

        public IResult Update(Order order)
        {
            var result=_orderDal.Update(order);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.Unsuccessful);
        }

        public IDataResult<List<Order>> GetActiveOrdersDetailsByRestaurantId(string restaurantId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(x=>x.RestaurantId == restaurantId && ((x.OrderStatus == "Kuryede") || x.OrderStatus == "Hazırlanıyor" || x.OrderStatus == "Alındı")), Messages.Successful);    
        }

        public IDataResult<List<Order>> GetPassiveOrdersDetailsByRestaurantId(string restaurantId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(x => x.RestaurantId == restaurantId && x.OrderStatus == "Tamamlandı" ), Messages.Successful);
        }

        public IDataResult<OrdersByDateDto> GetTodayOrders()
        {
            return new SuccessDataResult<OrdersByDateDto>(_orderDal.GetOrdersByDate(DateTime.Today.ToString("dd.MM.yyyy")),Messages.Successful);
        }

        public IDataResult<OrdersByDateDto> GetYesterdayOrders()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            string yesterdayString = yesterday.ToString("dd.MM.yyyy");
            return new SuccessDataResult<OrdersByDateDto>(_orderDal.GetOrdersByDate(yesterdayString), Messages.Successful);
        }

        public IDataResult<List<OrdersByRestaurantDto>> OrderMenusByRestaurantId(string restaurantId)
        {
            return new SuccessDataResult<List<OrdersByRestaurantDto>>(_orderDal.GetOrdersByRestaurantId(restaurantId),Messages.Successful);
        }
    }
}
