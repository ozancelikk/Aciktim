using Core.Entities.Abstract;
using Core.Entities.Concrete.DBEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserClaimDto : IDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public bool Status { get; set; }
        public List<OperationClaim> OperationClaims { get; set; }

    }
}
