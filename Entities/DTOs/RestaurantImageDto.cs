using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RestaurantImageDto : IDto
    {
        public string RestaurantId { get; set; }
        public string? ImagePath { get; set; }
    }
}
