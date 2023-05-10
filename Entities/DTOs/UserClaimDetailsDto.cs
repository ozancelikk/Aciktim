using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserClaimDetailsDto : IDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string OperationClaimName { get; set; }
        public string OperationClaimId { get; set; }
    }
}
