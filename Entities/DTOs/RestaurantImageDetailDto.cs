using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RestaurantImageDetailDto:IDto
    {
        public string Id { get; set; }
        public string RestaurantName { get; set; }
        public string MailAddress { get; set; }
        public string RestaurantAddress { get; set; }
        public string OpeningTime { get; set; }
        public string PhoneNumber { get; set; }
        public string ClosingTime { get; set; }
        public string CategoryId { get; set; }
        public double RestaurantRate { get; set; }
        public double MinCartPrice { get; set; }
        public string TaxNumber { get; set; }
        public string ImagePath { get; set; }
        public string RegisterDate { get; set; }
    }
}
