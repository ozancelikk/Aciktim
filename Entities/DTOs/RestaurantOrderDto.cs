using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RestaurantOrderDto : IDto
    {
        public string RestaurantName { get; set; }
        public int RestaurantOrderNumber { get; set; }
    }
}
