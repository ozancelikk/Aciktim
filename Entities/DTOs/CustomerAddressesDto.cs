using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerAddressesDto : IDto
    {
        public string CustomerId { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string NeighbourHood { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }
        public string DoorNumber { get; set; }
        public string Address { get; set; }
    }
}
