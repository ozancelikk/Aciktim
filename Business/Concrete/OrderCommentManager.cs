using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            return new SuccessResult();

        }

        public IResult Delete(string id)
        {
            var orderComment=GetById(id);
            if (orderComment.Data==null)
            {
                return new ErrorResult();
            }
            var result = _orderCommentDal.Delete(orderComment.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<OrderComment>> GetAll()
        {
            return new SuccessDataResult<List<OrderComment>>(_orderCommentDal.GetAll());
        }

        public IDataResult<OrderComment> GetById(string id)
        {
            return new SuccessDataResult<OrderComment>(_orderCommentDal.Get(o=>o.Id==id));
        }

        public IResult Update(OrderComment orderCommet)
        {
            var result = _orderCommentDal.Update(orderCommet);
            if (result.MatchedCount>0)
            {
                return new SuccessResult();
            }
            throw new FormatException();
        }
    }
}
