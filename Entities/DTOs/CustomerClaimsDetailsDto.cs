using Core.Entities.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerClaimsDetailsDto : IDto
    {
        public string Mail { get; set; }
        public string ClaimName { get; set; }
    }
}
