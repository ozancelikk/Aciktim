using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderMenuDetail
    {
        public double OrderPrice { get; set; }
        public string RestaurantId { get; set; }
        public string MenuName { get; set; }
        public string MenuImage { get; set; }
        public int Quantity { get; set; }
    }
}
