using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerOrdersByOrderNumberDto : IDto
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
    }
}
