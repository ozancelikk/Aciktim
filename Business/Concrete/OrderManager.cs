﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IDataResult<Order> GetById(string id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.Id == id), Messages.Successful);
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
    }
}