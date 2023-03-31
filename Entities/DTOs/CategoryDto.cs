using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CategoryDto:IDto
    {
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
    }
}
