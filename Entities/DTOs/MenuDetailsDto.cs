using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MenuDetailsDto : IDto
    {
        public string Id { get; set; }
        public string? MenuImage { get; set; }
        public string MenuTitle { get; set; }
        public string RestaurantId { get; set; }
        public string MenuDescription { get; set; }
        public double MenuPrice { get; set; }
        public string RestaurantName { get; set; }
    }
}
