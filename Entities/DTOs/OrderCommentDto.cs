using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OrderCommentDto:IDto
    {
        public string OrderId { get; set; }
        public string? Content { get; set; }
        public string RestaurantName { get; set; }
        public string CustomerMail { get; set; }
        public int? OrderStar { get; set; }
        public string OrderCommentDate { get; set; }
    }
}
