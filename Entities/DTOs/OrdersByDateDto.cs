using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrdersByDateDto : IDto
    {
        public string Date { get; set; }
        public int Count { get; set; }
    }
}
