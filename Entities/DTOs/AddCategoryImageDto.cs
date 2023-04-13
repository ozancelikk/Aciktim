using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AddCategoryImageDto : IDto
    {
        public string CategoryId { get; set; }
        public string? ImagePath { get; set; }
    }
}
