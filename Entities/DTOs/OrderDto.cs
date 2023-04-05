using Core.Entities.Abstract;
using Core.Entities.Concrete.DBEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OrderDto:IDto
    {
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public Restaurant Restaurant { get; set; }
        public string OrderDescription { get; set; }
        public double OrderPrice { get; set; }
        public bool OrderStatus { get; set; }
        public string EstimatedTime { get; set; }
    }
}
