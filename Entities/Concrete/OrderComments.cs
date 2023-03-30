using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class OrderComments:IEntity
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string? Content { get; set; }
        public int? OrderStar { get; set; }
        public string OrderDate { get; set; }
    }
}
