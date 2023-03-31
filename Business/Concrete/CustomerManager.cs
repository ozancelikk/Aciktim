using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult("Müşteri Eklendi");
        }

        public IResult Delete(string id)
        {
            var customer = GetById(id);
            if (customer.Data==null)
            {
                return new ErrorResult("Kullanıcı Bulunamadı");
            }
            var result = _customerDal.Delete(customer.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult("Kullanıcı silindi");
            }
            return new ErrorResult("Kullanıcıyı silerken hata oluştu");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),"Kullanıcılar listelendi"); 
        }

        public IDataResult<Customer> GetById(string id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id),"Kullanıcı listelendi");
        }

        public IResult Update(Customer customer)
        {
            var result=_customerDal.Update(customer);
            if (result.MatchedCount>0)
            {
                return new SuccessResult("Güncelleme Başarılı");
            }
            throw new FormatException("Güncelleme sırasında hata oldu");
        }
    }
}
