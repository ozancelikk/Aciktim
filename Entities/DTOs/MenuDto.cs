using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class MenuDto:IDto
    {
        public string RestaurantId { get; set; }
        public string MenuTitle { get; set; }
        public string MenuDescription { get; set; }
        public string MenuImage { get; set; }
        public double MenuPrice { get; set; }
        public List<string> MenuProperties { get; set; }
    }
}
