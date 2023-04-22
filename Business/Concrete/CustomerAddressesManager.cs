using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerAddressesManager : ICustomerAddressService
    {
        private readonly ICustomerAddressesDal _customerAddressesDal;

        public CustomerAddressesManager(ICustomerAddressesDal customerAddressesDal)
        {
            _customerAddressesDal = customerAddressesDal;
        }

        public IResult Add(CustomerAddresses customerAddress)
        {
            _customerAddressesDal.Add(customerAddress);
            return new SuccessResult(Messages.Successful);
        }

        public IResult Delete(string id)
        {
            var customer = GetById(id);
            if (customer.Data == null)
            {
                return new ErrorResult(Messages.Unsuccessful);
            }
            var result = _customerAddressesDal.Delete(customer.Data);
            if (result.DeletedCount > 0)
            {
                return new SuccessResult(Messages.DeletionSuccessful);
            }
            return new ErrorResult(Messages.Unsuccessful);
        }

        public IDataResult<List<CustomerAddressesDto>> GetAll()
        {
            return new SuccessDataResult<List<CustomerAddressesDto>>(_customerAddressesDal.GetAllAddresses(), Messages.Successful);
        }

        public IDataResult<List<CustomerAddresses>> GetAllByCustomerId(string customerId)
        {
            return new SuccessDataResult<List<CustomerAddresses>>(_customerAddressesDal.GetAll(x=>x.CustomerId == customerId), Messages.Successful);
        }

        public IDataResult<CustomerAddresses> GetById(string id)
        {
            return new SuccessDataResult<CustomerAddresses>(_customerAddressesDal.Get(c => c.Id == id), Messages.Successful);
        }

        public IResult Update(CustomerAddresses customerAddress)
        {
            var result = _customerAddressesDal.Update(customerAddress);
            if (result.MatchedCount > 0)
            {
                return new SuccessResult(Messages.UpdateSuccessful);
            }
            throw new FormatException(Messages.Unsuccessful);
        }
    }
}
