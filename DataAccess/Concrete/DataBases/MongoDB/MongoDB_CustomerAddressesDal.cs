using AutoMapper;
using Core.DataAccess.Databases.MongoDB;
using DataAccess.Abstract;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_CustomerAddressesDal : MongoDB_RepositoryBase<CustomerAddresses, MongoDB_Context<CustomerAddresses, MongoDB_CustomerAddressesCollection>>, ICustomerAddressesDal
    {
        private readonly IMapper _mapper;

        public MongoDB_CustomerAddressesDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CustomerAddressesDto> GetAllAddresses()
        {
            List<CustomerAddresses> customersAddresses = new List<CustomerAddresses>();
            using (var customerContext = new MongoDB_Context<CustomerAddresses, MongoDB_CustomerAddressesCollection>())
            {
                customerContext.GetMongoDBCollection();
                customersAddresses = customerContext.collection.Find<CustomerAddresses>(document => true).ToList();
                var customerAddressDtos = new List<CustomerAddressesDto>();
                foreach (var customerAddress in customersAddresses)
                {
                    if (customerAddress.Id != null)
                    {
                        customerAddressDtos.Add(new CustomerAddressesDto
                        {
                            Address = customerAddress.Address,
                            ApartmentNumber = customerAddress.ApartmentNumber,
                            City = customerAddress.City,
                            County = customerAddress.County,
                            CustomerId = customerAddress.CustomerId,
                            DoorNumber = customerAddress.DoorNumber,
                            NeighbourHood = customerAddress.NeighbourHood,
                            Street = customerAddress.Street
                        });
                    }
                }
                return customerAddressDtos;
            }
        }

        /*public List<CustomerAddresses> GetAllByCustomerId(string id)
        {
            using (var customerContext = new MongoDB_Context<CustomerAddresses, MongoDB_CustomerAddressesCollection>())
            {
                customerContext.GetMongoDBCollection();
                var customerAddresses = customerContext.collection.Find<CustomerAddresses>(document => true).ToList();
                var temp = customerAddresses.Where(x => x.CustomerId == id).ToList();
                return temp;
            }
        }*/
    }
}
