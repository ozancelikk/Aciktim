using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OrderDto:IDto
    {
        public string CustomerId { get; set; }
        public string RestaurantId { get; set; }
        public string OrderDescription { get; set; }
        public double OrderPrice { get; set; }
        public bool OrderStatus { get; set; }
        public string EstimatedTime { get; set; }
    }
}
