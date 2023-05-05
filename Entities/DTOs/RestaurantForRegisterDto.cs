using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RestaurantForRegisterDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string TaxNumber { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string PhoneNumber { get; set; }
        public string CategoryId { get; set; }
        public string RegisterDate { get; set; }
        public double MinCartPrice { get; set; }
    }
}
