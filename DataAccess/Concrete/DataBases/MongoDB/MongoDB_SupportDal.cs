using Core.DataAccess.Databases.MongoDB;
using Core.Entities.Concrete.DBEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.Databases.MongoDB.Collections;
using DataAccess.Concrete.DataBases.MongoDB.Collections;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.DataBases.MongoDB
{
    public class MongoDB_SupportDal : MongoDB_RepositoryBase<Support, MongoDB_Context<Support, MongoDB_SupportCollection>>, ISupportDal
    {
        public List<SupportListDto> GetSupportDetails()
        {
            List<SupportListDto > list = new List<SupportListDto>();
            List<Support> supports = new List<Support>();
            using var supportContext = new MongoDB_Context<Support, MongoDB_SupportCollection>();
            supportContext.GetMongoDBCollection();
            supports = supportContext.collection.Find<Support>(document => true).ToList();


            List<Customer> customers = new List<Customer>();
            using var customerContext = new MongoDB_Context<Customer, MongoDB_CustomerCollection>();
            customerContext.GetMongoDBCollection();
            customers = customerContext.collection.Find<Customer>(document => true).ToList();

            foreach (var item in supports)
            {
                var customer = customers.Where(x=>x.Id == item.CustomerId).FirstOrDefault();
                if (customer != null)
                {
                    list.Add(new SupportListDto
                    {
                        CustomerId = item.CustomerId,
                        Content = item.Content,
                        CustomerName = customer.FirstName + " " + customer.LastName,
                        Id = item.Id,
                        Mail = item.Mail,
                        Subject = item.Subject,
                    });
                }

            }
            return list;

        }

        public SupportListDto GetSupportDetailsById(string id)
        {
            var temp = new SupportListDto();

            List<Support> supports = new List<Support>();
            using var supportContext = new MongoDB_Context<Support, MongoDB_SupportCollection>();
            supportContext.GetMongoDBCollection();
            supports = supportContext.collection.Find<Support>(document => true).ToList();


            List<Customer> customers = new List<Customer>();
            using var customerContext = new MongoDB_Context<Customer, MongoDB_CustomerCollection>();
            customerContext.GetMongoDBCollection();
            customers = customerContext.collection.Find<Customer>(document => true).ToList();

            
            var support = supports.Find(x => x.Id == id); //ilgili mail
            var customer = customers.Find(x => x.Id == support.CustomerId);

            if(customer != null && customer !=null) 
            {
                temp.Subject = support.Subject;
                temp.CustomerId = support.CustomerId;
                temp.Id = support.Id;
                temp.Mail = support.Mail;
                temp.Content = support.Content;
                temp.CustomerName = customer.FirstName + " " + customer.LastName;
            }
            return temp;
            
        }
    }
}
