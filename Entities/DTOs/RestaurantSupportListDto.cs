using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RestaurantSupportListDto : IDto
    {
        public string Id { get; set; }
        public string RestaurantName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string RestaurantId { get; set; }
        public string Mail { get; set; }
    }
}
