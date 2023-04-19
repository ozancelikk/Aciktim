using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailsDto : IDto
    {
        public string CustomerId { get; set; }
        public string RestaurantId { get; set; }
        public string OrderDescription { get; set; }
        public double OrderPrice { get; set; }
        public string RestaurantName { get; set; }
        public string MenuName { get; set; }
        public string OrderStatus { get; set; }
        public string EstimatedTime { get; set; }
    }
}
