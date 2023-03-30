using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FoodImage : IEntity
    {
        public string Id  { get; set; }
        public string? FoodCategoryId { get; set; }
        public string? ImagePath { get; set; }

    }
}
