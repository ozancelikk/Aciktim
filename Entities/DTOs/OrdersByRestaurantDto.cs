using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrdersByRestaurantDto:IDto
    {
        public string MenuName { get; set; }
        public int Quantity { get; set; }
    }
}
