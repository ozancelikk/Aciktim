using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RestaurantSupportDto : IDto
    {
        public string RestaurantId { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
