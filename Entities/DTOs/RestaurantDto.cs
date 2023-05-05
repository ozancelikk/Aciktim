using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RestaurantDto:IDto
    {
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string TaxNumber { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string PhoneNumber { get; set; }
        public string CategoryId { get; set; }
        public double RestaurantRate { get; set; }
        public double MinCartPrice { get; set; }
        public string RegisterDate { get; set; }
        public bool Status { get; set; }

    }
}
