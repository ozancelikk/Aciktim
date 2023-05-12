﻿using Core.DataAccess.Databases.MongoDB;
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
    public class MongoDB_RestaurantCommentDal : MongoDB_RepositoryBase<RestaurantComment, MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>>, IRestaurantCommentDal
    {
        public List<RestaurantCommentDetailsDto> GetAllActiveComments()
        {
            List<RestaurantCommentDetailsDto> list = new List<RestaurantCommentDetailsDto>();
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => true).ToList();
            }

            List<Customer> _customers = new List<Customer>();
            using (var customers = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customers.GetMongoDBCollection();
                _customers = customers.collection.Find<Customer>(document => true).ToList();
            }

            List<RestaurantComment> comment = new List<RestaurantComment>();
            using (var comments = new MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>())
            {
                comments.GetMongoDBCollection();
                comment = comments.collection.Find<RestaurantComment>(document => document.Status == true).ToList();
            }
            foreach (var item in comment)
            {
                var currentCustomer = _customers.Find(x => x.Id == item.CustomerId);
                var currentRestaurant = restaurant.Find(x => x.Id == item.RestaurantId);
                var temp = new RestaurantCommentDetailsDto()
                {
                    CommentContent = item.CommentContent,
                    CommentDate = item.CommentDate,
                    CommentTitle = item.CommentTitle,
                    CustomerName = currentCustomer.FirstName + " " + currentCustomer.LastName,
                    RestaurantName = currentRestaurant.RestaurantName,
                    RestaurantRate = item.RestaurantRate,
                    Answer = item.Answer,
                    AnswerDate = item.AnswerDate,
                    Id = item.Id,
                    CustomerId = currentCustomer.Id,
                    RestaurantId = currentRestaurant.Id,
                    Status = item.Status,
                    
                };
                list.Add(temp);
            }
            return list;
        }

        public List<RestaurantCommentDetailsDto> GetAllPassiveComments()
        {
            List<RestaurantCommentDetailsDto> list = new List<RestaurantCommentDetailsDto>();
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => true).ToList();
            }

            List<Customer> _customers = new List<Customer>();
            using (var customers = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customers.GetMongoDBCollection();
                _customers = customers.collection.Find<Customer>(document => true).ToList();
            }

            List<RestaurantComment> comment = new List<RestaurantComment>();
            using (var comments = new MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>())
            {
                comments.GetMongoDBCollection();
                comment = comments.collection.Find<RestaurantComment>(document => document.Status == false).ToList();
            }
            foreach (var item in comment)
            {
                var currentCustomer = _customers.Find(x => x.Id == item.CustomerId);
                var currentRestaurant = restaurant.Find(x => x.Id == item.RestaurantId);
                var temp = new RestaurantCommentDetailsDto()
                {
                    CommentContent = item.CommentContent,
                    CommentDate = item.CommentDate,
                    CommentTitle = item.CommentTitle,
                    CustomerName = currentCustomer.FirstName + " " + currentCustomer.LastName,
                    RestaurantName = currentRestaurant.RestaurantName,
                    RestaurantRate = item.RestaurantRate,
                    Answer = item.Answer,
                    AnswerDate = item.AnswerDate,
                    Id = item.Id,
                    CustomerId = currentCustomer.Id,
                    RestaurantId = currentRestaurant.Id,
                    Status = item.Status,
                };
                list.Add(temp);
            }
            return list;
        }

        public List<RestaurantCommentDetailsDto> GetCommentByCustomerId(string customerId,string resturantId)
        {
            List<RestaurantCommentDetailsDto> list = new List<RestaurantCommentDetailsDto>();
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => true).ToList();
            }

            List<Customer> _customers = new List<Customer>();
            using (var customers = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customers.GetMongoDBCollection();
                _customers = customers.collection.Find<Customer>(document => true).ToList();
            }

            List<RestaurantComment> comment = new List<RestaurantComment>();
            using (var comments = new MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>())
            {
                comments.GetMongoDBCollection();
                comment = comments.collection.Find<RestaurantComment>(document => document.CustomerId==customerId).ToList();
            }

            var myrestaurant = restaurant.Find(x => x.Id == resturantId); //ilgili restoran
            var currentRestaurantComments = comment.Where(x => x.RestaurantId == myrestaurant.Id).ToList();


            foreach (var item in currentRestaurantComments)
            {
                var currentCustomer = _customers.Find(x => x.Id == item.CustomerId);
                var temp = new RestaurantCommentDetailsDto()
                {
                    CommentContent = item.CommentContent,
                    CommentDate = item.CommentDate,
                    CommentTitle = item.CommentTitle,
                    CustomerName = currentCustomer.FirstName + " " + currentCustomer.LastName,
                    RestaurantName = myrestaurant.RestaurantName,
                    RestaurantRate = item.RestaurantRate,
                    Answer = item.Answer,
                    AnswerDate = item.AnswerDate,
                    Id = item.Id,
                    CustomerId = currentCustomer.Id,
                    RestaurantId = myrestaurant.Id,
                    Status = item.Status,
                };
                list.Add(temp);

            }
            return list;
        }

        public List<RestaurantCommentDetailsDto> GetCommentByRestaurantId(string restaurantId)
        {
            List<RestaurantCommentDetailsDto> list = new List<RestaurantCommentDetailsDto>();
            List<Restaurant> restaurant = new List<Restaurant>();
            using (var restaurants = new MongoDB_Context<Restaurant, MongoDB_RestaurantCollection>())
            {
                restaurants.GetMongoDBCollection();
                restaurant = restaurants.collection.Find<Restaurant>(document => true).ToList();      
            }

            List<Customer> _customers = new List<Customer>();
            using (var customers = new MongoDB_Context<Customer, MongoDB_CustomerCollection>())
            {
                customers.GetMongoDBCollection();
                _customers = customers.collection.Find<Customer>(document => true).ToList();
            }

            List<RestaurantComment> comment = new List<RestaurantComment>();
            using (var comments = new MongoDB_Context<RestaurantComment, MongoDB_RestaurantCommentCollection>())
            {
                comments.GetMongoDBCollection();
                comment = comments.collection.Find<RestaurantComment>(document => true).ToList();
            }

                var myrestaurant = restaurant.Find(x => x.Id == restaurantId); //ilgili restoran
                var currentRestaurantComments = comment.Where(x=>x.RestaurantId == myrestaurant.Id).ToList();  


            foreach (var item in currentRestaurantComments)
            {
                var currentCustomer = _customers.Find(x => x.Id == item.CustomerId); 
                var temp = new RestaurantCommentDetailsDto()
                {
                    CommentContent = item.CommentContent,
                    CommentDate = item.CommentDate,
                    CommentTitle = item.CommentTitle,
                    CustomerName = currentCustomer.FirstName + " " + currentCustomer.LastName,
                    RestaurantName = myrestaurant.RestaurantName,
                    RestaurantRate = item.RestaurantRate,
                    Answer=item.Answer,
                    AnswerDate=item.AnswerDate,
                    Id = item.Id,
                    CustomerId=currentCustomer.Id,
                    RestaurantId=myrestaurant.Id,
                    Status = item.Status,
                };
                list.Add(temp);
               
            }
            return list;
        }
    }
}
