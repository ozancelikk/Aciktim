using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FoodCategory : IEntity
    {
        public string Id { get; set; }
        public string? FoodCategoryName { get; set; }
        
    }
}
