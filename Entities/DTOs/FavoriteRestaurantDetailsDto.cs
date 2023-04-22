using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class FavoriteRestaurantDetailsDto:IDto
    {
        public string CustomerId { get; set; }
        public string RestaurantId { get; set; }
    }
}
