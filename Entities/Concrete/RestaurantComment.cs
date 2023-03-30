using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RestaurantComment : IEntity
    {
        public string Id { get; set; }
        public string? RestaurantId { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
    }
}
