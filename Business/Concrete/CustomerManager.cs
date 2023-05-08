using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete.DBEntities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.DTOs;
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
            return new SuccessResult(Messages.Successful);
        }

        public IResult ChangeForgottenPassword(Customer customer)
        {
           _customerDal.Update(customer); 
            return new SuccessResult(Messages.Successful);
        }

        public IResult Delete(string id)
        {
            var customer = GetById(id);
            if (customer.Data==null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _customerDal.Delete(customer.Data);
            if (result.DeletedCount>0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<List<CustomerDto>> GetAll()
        {
            return new SuccessDataResult<List<CustomerDto>>(_customerDal.GetAllCustomer(), Messages.Successful); 
        }

        public IDataResult<List<CustomerDetailsDto>> GetAllWithId()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.GetAllCustomerWithId(),Messages.Successful);
        }

        public IDataResult<Customer> GetById(string id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.Successful);
        }

        public IDataResult<Customer> GetByMail(string mail)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.MailAddress == mail),Messages.Successful);
        }

        public IDataResult<List<OperationClaim>> GetClaims(Customer customer)
        {
            return new SuccessDataResult<List<OperationClaim>>(_customerDal.GetClaims(customer),Messages.Successful);
        }

        public IDataResult<CustomerDto> GetCustomerDetailsByMail(string mail)
        {
            return new SuccessDataResult<CustomerDto>(_customerDal.GetCustomerByMail(mail),Messages.Successful);
        }

        public IDataResult<List<CustomerOrdersByOrderNumberDto>> GetCustomerOrdersByOrderNumbers()
        {
           return new SuccessDataResult<List<CustomerOrdersByOrderNumberDto>>(_customerDal.GetCustomerOrdersByOrderNumbers(),Messages.Successful);
        }

        public IDataResult<int> GetCustomersByTodayRegisterDate()
        {
            return new SuccessDataResult<int>(_customerDal.GetCustomersByTodayRegisterDate(),Messages.Successful);
        }

        public IDataResult<CustomerDetailsDto> GetDetailsById(string id)
        {
            return new SuccessDataResult<CustomerDetailsDto>(_customerDal.GetCustomerById(id), Messages.Successful);
        }

        public IResult Update(Customer customer)
        {
            var result=_customerDal.Update(customer);
            if (result.MatchedCount>0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.Unsuccessful);
        }
    }
}
