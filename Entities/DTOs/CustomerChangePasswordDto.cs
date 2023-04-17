using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerChangePasswordDto : IDto
    {
        public string EMail { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
