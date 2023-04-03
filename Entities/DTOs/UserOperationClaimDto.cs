using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserOperationClaimDto : IDto
    {
        public string UserId { get; set; }
        public string OperationClaimId { get; set; }
    }
}
