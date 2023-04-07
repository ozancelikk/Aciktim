using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderCommentManager : IOrderCommentService
    {
        private readonly IOrderCommentDal _orderCommentDal;
        public OrderCommentManager(IOrderCommentDal orderCommentDal)
        {
            _orderCommentDal= orderCommentDal;
        }
        public IResult Add(OrderComment orderCommet)
        {
            _orderCommentDal.Add(orderCommet);
            return new SuccessResult(Messages.AddingSuccessful);

        }

        public IResult Delete(string id)
        {
            var orderComment=GetById(id);
            if (orderComment.Data==null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _orderCommentDal.Delete(orderComment.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<List<OrderComment>> GetAll()
        {
            return new SuccessDataResult<List<OrderComment>>(_orderCommentDal.GetAll(), Messages.Successful);
        }

        public IDataResult<OrderComment> GetById(string id)
        {
            return new SuccessDataResult<OrderComment>(_orderCommentDal.Get(o=>o.Id==id), Messages.Successful);
        }

        public IDataResult<List<OrderCommentDto>> GetByRestaurantId(string id)
        {
            return new SuccessDataResult<List<OrderCommentDto>>(_orderCommentDal.GetOrderCommentsByRestaurantId(id), Messages.Successful);
        }

        public IResult Update(OrderComment orderCommet)
        {
            var result = _orderCommentDal.Update(orderCommet);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.Unsuccessful);
        }
    }
}
