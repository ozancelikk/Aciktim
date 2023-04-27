using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class SupportDto : IDto
    {
        public string CustomerId { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
