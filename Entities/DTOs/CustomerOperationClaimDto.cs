using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerOperationClaimDto:IDto
    {
        public string CustomerId { get; set; }
        public string OperationClaimId { get; set; }
    }
}
