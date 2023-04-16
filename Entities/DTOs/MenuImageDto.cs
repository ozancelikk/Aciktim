using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MenuImageDto : IDto
    {
        public string MenuId { get; set; }
        public string? ImagePath { get; set; }
    }
}
