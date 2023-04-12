using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class FavoriteRestaurantDto:IDto
    {
        public string CustomerId { get; set; }
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string? RestaurantImage { get; set; }
        public bool Status { get; set; }
    }
}
