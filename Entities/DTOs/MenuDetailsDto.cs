using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MenuDetailsDto : IDto
    {
        public string? MenuImage { get; set; }
        public string MenuTitle { get; set; }
        public string MenuDescription { get; set; }
        public double MenuPrice { get; set; }
    }
}
