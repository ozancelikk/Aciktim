using Core.Entities.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OrderDto:IDto
    {
        public string FirstName { get; set; }
        public string CustomerId { get; set; }
        public List<OrderMenuDetail>? Menus { get; set; }
        public string LastName { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantId { get; set; }
        public string Address { get; set; }
        public string OrderDate { get; set; }
        public string PhoneNumber { get; set; }
        public string OrderDescription { get; set; }
        public string OrderStatus { get; set; }
        public string EstimatedTime { get; set; }
    }
}
